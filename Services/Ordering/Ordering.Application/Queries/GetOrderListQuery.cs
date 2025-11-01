using MediatR;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Queries
{
    public class GetOrderListQuery(string userName) : IRequest<List<OrderResponse>>
    {
        public string UserName { get; set; } = userName;
    }
}
