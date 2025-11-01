using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
    public class GetProductByBrandQueryHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetProductByBrandQuery, IList<ProductResponseDto>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<IList<ProductResponseDto>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var productsList = await _productRepository.GetProductsByBrand(request.Name);
            return _mapper.Map<IList<ProductResponseDto>>(productsList);
        }
    }
}
