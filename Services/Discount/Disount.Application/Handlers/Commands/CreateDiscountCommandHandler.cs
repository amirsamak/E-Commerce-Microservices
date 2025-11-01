using AutoMapper;
using Discount.Grpc.Protos;
using Disount.Application.Queries;
using Disount.Core.Entities;
using Disount.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Application.Handlers.Commands
{
    public class CreateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper) : IRequestHandler<GetDiscountQuery, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository = discountRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(request);
            await _discountRepository.CreateDiscount(coupon);
            return _mapper.Map<CouponModel>(coupon);
        }


    }
}
