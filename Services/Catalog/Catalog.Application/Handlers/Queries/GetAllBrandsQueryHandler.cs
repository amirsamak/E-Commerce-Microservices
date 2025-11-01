using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
    public class GetAllBrandsQueryHandler(IMapper mapper , IBrandRepository brandRepository) : IRequestHandler<GetAllBrandsQuery, IList<BrandResponseDto>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IBrandRepository _brandRepository = brandRepository;

        public async Task<IList<BrandResponseDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brandList = await _brandRepository.GetAllBrands();
            //return _mapper.Map<IList<BrandResponseDto>>(brandList);
            return _mapper.Map<IList<ProductBrand>,IList<BrandResponseDto>>(brandList.ToList());
        }
    }
}
