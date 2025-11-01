using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entities
{
    public class ShoppingCart(string userName)
    {
        public string UserName { get; set; } = userName;
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
