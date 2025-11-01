using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Commands
{
    public class CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository) : IRequestHandler<CreateProductCommand, ProductResponseDto>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IProductRepository _productRepository = productRepository;
        public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
            var newProduct = await _productRepository.Create(productEntity);
            return _mapper.Map<ProductResponseDto>(newProduct);
        }
    }
}
