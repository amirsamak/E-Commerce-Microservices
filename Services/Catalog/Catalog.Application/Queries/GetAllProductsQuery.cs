using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    // public class GetAllProductsQuery :IRequest<IList<ProductResponseDto>>
    public class GetAllProductsQuery(CatalogSpecParams catalogSpecParams) : IRequest<Pagination<ProductResponseDto>>
    {
       // public readonly CatalogSpecParams catalogSpecParams = catalogSpecParams;
        public CatalogSpecParams catalogSpecParams { get; set; } = catalogSpecParams;
    }
}
