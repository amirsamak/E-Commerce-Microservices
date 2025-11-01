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
    public class GetAllTypesQueryHandler(ITypeRepository typeRepository , IMapper mapper) : IRequestHandler<GetAllTypesQuery, IList<TypeResponseDto>>
    {
        private readonly ITypeRepository _typeRepository = typeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IList<TypeResponseDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typeList = await _typeRepository.GetAllTypes();
            return _mapper.Map<IList<TypeResponseDto>>(typeList);
        }
    }
}
