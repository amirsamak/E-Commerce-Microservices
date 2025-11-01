using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Infrastructure.Extentions
{
    public static class DbExtention 
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var config = service.GetRequiredService<IConfiguration>();
                var logger = service.GetRequiredService<ILogger<TContext>>();
                try
                {
                    logger.LogInformation("Discount DB Migration started.");
                    ApplyMigrations(config);

                    logger.LogInformation("Discount DB Migration completed.");

                    
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Cannot Create Discount database.");
                    Console.WriteLine("An error occurred while migrating the database: " + ex.Message);
                }
            }
            return host;
        }

        private static void ApplyMigrations(IConfiguration config)
        {
            var retry = 5;
            while(retry > 0)
            {
                try
                {
                    using var connection = new Npgsql.NpgsqlConnection(
                        config.GetValue<string>("DatabaseSettings:ConnectionString"));
                    connection.Open();

                    using var command = new Npgsql.NpgsqlCommand
                    {
                        Connection = connection
                    };

                    command.CommandText = "DROP TABLE IF EXISTS Coupon";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE Coupon(
                                    Id SERIAL PRIMARY KEY,
                                    ProductName VARCHAR(500) NOT NULL,
                                    Description TEXT,
                                    Amount INT
                                    )";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Egypt Adidas Quick Force Indoor Badminton Shoes', 'Adidas Discount', 150);";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('Asics Gel Rocket 8 Indoor Court Shoes', 'Asics Discount', 100);";
                    command.ExecuteNonQuery();

                    break;
                }
                catch (Exception ex)
                {
                    retry--;
                    if (retry == 0)
                    {
                        throw;
                    }
                    Thread.Sleep(2000);
                }
            }
          
        }
    }
}
