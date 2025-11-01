using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands
{
    public class CreateShoppingCartCommand(string userName, List<ShoppingCartItem> items) : IRequest<ShoppingCartResponseDTO>
    {
        public string UserName { get; set; } = userName;
        public List<ShoppingCartItem> Items { get; set; } = items;
    }
}
