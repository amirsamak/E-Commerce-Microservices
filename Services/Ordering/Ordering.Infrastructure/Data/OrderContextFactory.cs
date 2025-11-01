using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextFactory : IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<OrderContext>();
            optionBuilder.UseSqlServer("Server=DESKTOP-8HN3544\\SQLEXPRESS;Database=OrderDb2;User Id=sa;Password=123;TrustServerCertificate=True;");
            return new OrderContext(optionBuilder.Options);
        }
    }
}
