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
    public class GetProductsByNameQueryHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetProductsByNameQuery, IList<ProductResponseDto>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<IList<ProductResponseDto>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var product =await _productRepository.GetProductsByName(request.Name);
            return _mapper.Map<IList<ProductResponseDto>>(product);
        }
    }
}
