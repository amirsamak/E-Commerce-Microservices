using Disount.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Core.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(String productName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(String productName);
    }
}
