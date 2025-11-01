using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
    public class GetAllProductsQueryHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, Pagination<ProductResponseDto>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<Pagination<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllProducts(request.catalogSpecParams);
            //return _mapper.Map<IList<Product>, IList<ProductResponseDto>>(productList.ToList());
            return _mapper.Map<Pagination<ProductResponseDto>>(productList);
        }
    }
}
