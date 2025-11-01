using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository(ICatalogContext catalogContext) : IProductRepository, IBrandRepository, ITypeRepository
    {
        private readonly ICatalogContext _catalogContext = catalogContext;

        public async Task<Product> GetProductById(string id)
        {
            return await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Create(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> Delete(string id)
        {
            var deleteProduct = await _catalogContext.Products.DeleteOneAsync(p => p.Id == id);
            return deleteProduct.IsAcknowledged && deleteProduct.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {

            return await _catalogContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<Pagination<Product>> GetAllProducts(CatalogSpecParams catalogSpecParams)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(catalogSpecParams.Search))
            {
                filter = filter & builder.Where(p => p.Name.ToLower().Contains(catalogSpecParams.Search.ToLower()));
            }

            if (!string.IsNullOrEmpty(catalogSpecParams.BrandId))
            {
                filter = filter & builder.Eq(p => p.Brand.Id, catalogSpecParams.BrandId);
            }

            if (!string.IsNullOrEmpty(catalogSpecParams.TypeId))
            {
                filter = filter & builder.Eq(p => p.Type.Id, catalogSpecParams.TypeId);
            }

            var totalItems = await _catalogContext.Products.CountDocumentsAsync(filter);
            var products = await DataFilter(catalogSpecParams, filter);

            return new Pagination<Product>(catalogSpecParams.PageIndex, catalogSpecParams.PageSize, (int)totalItems, products);
        }

        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await _catalogContext.Types.Find(t => true).ToListAsync();
        }



        public async Task<IEnumerable<Product>> GetProductsByBrand(string name)
        {
            return await _catalogContext.Products.Find(p => p.Brand.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _catalogContext.Products.Find(p => p.Name == name).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var updatedProduct = await _catalogContext.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await _catalogContext.Brands.Find(b => true).ToListAsync();
        }

        private async Task<IReadOnlyList<Product>> DataFilter(CatalogSpecParams catalogSpecParams, FilterDefinition<Product> filter)
        {
            var sortDef = Builders<Product>.Sort.Ascending(p => p.Name);
            if (!string.IsNullOrEmpty(catalogSpecParams.Sort))
            {
                switch (catalogSpecParams.Sort.ToLower())
                {
                    case "priceasc":
                        sortDef = Builders<Product>.Sort.Ascending(p => p.Price);
                        break;
                    case "pricedesc":
                        sortDef = Builders<Product>.Sort.Descending(p => p.Price);
                        break;
                    default:
                        sortDef = Builders<Product>.Sort.Ascending(p => p.Name);
                        break;
                }
            }
            return await _catalogContext.Products.Find(filter)
                .Sort(sortDef)
                .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                .Limit(catalogSpecParams.PageSize)
                .ToListAsync();
        }
    }
}
