using AutoMapper;
using Discount.Grpc.Protos;
using Disount.Application.Commands;
using Disount.Core.Entities;
using Disount.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Application.Handlers.Commands
{
    public class UpdateDiscoutCommandHandler(IDiscountRepository discountRepository, IMapper mapper) : IRequestHandler<UpdateDiscoutCommand, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository = discountRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<CouponModel> Handle(UpdateDiscoutCommand request, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(request);
            await _discountRepository.UpdateDiscount(coupon);
            return _mapper.Map<CouponModel>(coupon);
        }
    }
}
