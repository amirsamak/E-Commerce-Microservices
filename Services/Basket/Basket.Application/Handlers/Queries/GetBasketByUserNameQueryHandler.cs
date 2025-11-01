using AutoMapper;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers.Queries
{
    public class GetBasketByUserNameQueryHandler(IBasketRepository basketRepository,IMapper mapper) : IRequestHandler<GetBasketByUserNameQuery, ShoppingCartResponseDTO>
    {
        private readonly IBasketRepository _basketRepository = basketRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ShoppingCartResponseDTO> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart =await _basketRepository.GetBasket(request.UserName);
            return _mapper.Map<ShoppingCartResponseDTO>(shoppingCart);
        }
    }
}
 