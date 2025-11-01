using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetProductsByNameQuery(string name) : IRequest<IList<ProductResponseDto>>
    {
        public string Name { get; set; } = name;
    }
}
