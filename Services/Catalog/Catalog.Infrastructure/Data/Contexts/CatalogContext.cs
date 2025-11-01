using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configurations)
        {
            var client = new MongoClient(configurations["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configurations["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configurations["DatabaseSettings:ProductsCollection"]);
            Brands = database.GetCollection<ProductBrand>(configurations["DatabaseSettings:BrandsCollection"]);
            Types = database.GetCollection<ProductType>(configurations["DatabaseSettings:TypesCollection"]);

            _= CatalogContextSeed.SeedDataAsync(Products);
            _ = BrandContextSeed.SeedDataAsync(Brands);
            _ = TypeContextSeed.SeedDataAsync(Types);
        }
        public IMongoCollection<Product> Products
        {
            get;
        }

        public IMongoCollection<ProductBrand> Brands
        {
            get;
        }

        public IMongoCollection<ProductType> Types
        {
            get;
        }
    }
}
