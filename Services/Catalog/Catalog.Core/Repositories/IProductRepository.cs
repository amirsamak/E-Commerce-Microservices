using Catalog.Core.Entities;
using Catalog.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Pagination<Product>> GetAllProducts(CatalogSpecParams catalogSpecParams);
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductsByBrand(string name);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<Product> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}
