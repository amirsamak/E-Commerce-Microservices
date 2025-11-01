using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Core.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        //public string Code { get; set; }
        //public decimal DiscountAmount { get; set; }
        public int Amount { get; set; }
        //public DateTime ExpirationDate { get; set; }
        //public bool IsActive { get; set; }
    }
}
