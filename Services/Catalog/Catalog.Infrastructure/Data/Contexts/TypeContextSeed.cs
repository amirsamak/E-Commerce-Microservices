using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class TypeContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductType> typeCollections)
        {
            var hasTypes = await typeCollections.Find(_ => true).AnyAsync();
            if (hasTypes)
                return;

            //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData" , "brands.json");
            var filePath = Path.Combine("Data", "SeedData", "types.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Seed File not exist : {filePath}");
                return;
            }


            var typesData = await File.ReadAllTextAsync(filePath);
            var types = System.Text.Json.JsonSerializer.Deserialize<List<ProductType>>(typesData);
            if (types != null && types.Any())
            {
                await typeCollections.InsertManyAsync(types);
            }
        }
    }
}
