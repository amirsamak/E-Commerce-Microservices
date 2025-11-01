using Discount.Grpc.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Application.Queries
{
    public class GetDiscountQuery(string productName) : IRequest<CouponModel>
    {
        public string ProductName { get; set; } = productName;
    }
}
