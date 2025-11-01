using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class BrandContextSeed
    {
        public static async Task SeedDataAsync (IMongoCollection<ProductBrand> productCollections)
        {
            var hasBrands = await productCollections.Find(_ => true).AnyAsync();
            if (hasBrands)
                return; 

            //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData" , "brands.json");
            var filePath = Path.Combine( "Data", "SeedData" , "brands.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Seed File not exist : {filePath}");
                return;
            }
                

            var brandData = await File.ReadAllTextAsync(filePath);
            var brands = System.Text.Json.JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

            //if (brands?.Any() is true)
            if (brands != null && brands.Any())
            {
                await productCollections.InsertManyAsync(brands);
            }
        }
    }
}
