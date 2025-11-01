using Discount.Grpc.Protos;
using Disount.Application.Queries;
using Disount.Core.Repositories;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Application.Handlers.Queries
{
    public class GetDiscountQueryHandler(IDiscountRepository discountRepository,ILogger<GetDiscountQueryHandler> logger) : IRequestHandler<GetDiscountQuery, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository = discountRepository;
        private readonly ILogger<GetDiscountQueryHandler> _logger = logger;

        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _discountRepository.GetDiscount(request.ProductName);
           
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount for product name ={request.ProductName} not found"));
            }
            _logger.LogInformation("Discount retrieved for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);
            return new CouponModel
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount
            };
        }
    }
}
