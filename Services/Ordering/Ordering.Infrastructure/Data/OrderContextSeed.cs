using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database :{typeof(OrderContext).Name} seeded!");
            }
        }

        public static IEnumerable<Order> GetOrders()
        {
            return new List<Order> {
                new()
                {
                    UserName="amirsamak",
                    FirstName="amir",
                    LastName="Samak",
                    EmailAddress="amir@eCommerce.net",
                    AddressLine="Cairo",
                    Country="Egypt",
                    TotalPrice=750,
                    State="EG",
                    ZipCode="71111",

                    CardName="Visa",
                    CardNumber="1234567890123456",
                    CreatedBy="amir",
                    Expiration="12/26",
                    Cvv="123",
                    PaymentMethod=1,
                    LastModifiedBy="amir",
                    LastModifiedDate=new DateTime()
                }
            };
        }
    }
}
