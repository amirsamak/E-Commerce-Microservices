using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.GrpcServices;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers.Commands
{
    public class CreateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper, DiscountGrpcService discountGrpcService) : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponseDTO>
    {
        private readonly IBasketRepository _basketRepository = basketRepository;
        private readonly IMapper _mapper = mapper;
        private readonly DiscountGrpcService _discountGrpcService = discountGrpcService;
        public async Task<ShoppingCartResponseDTO> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            //ToDo : Integrate with Discount gRPC to get discount for each product in the shopping cart
            foreach (var item in request.Items)
            {
                var coupon = _discountGrpcService.GetDiscount(item.ProductName);
                if (coupon != null)
                {
                    item.Price -= coupon.Result.Amount;
                }
            }
            var shoppingCart = await _basketRepository.UpdateBasket(new ShoppingCart(request.UserName)
            {
                UserName = request.UserName,
                Items = request.Items
            });
            return _mapper.Map<ShoppingCartResponseDTO>(shoppingCart);
        }
    }
}
