using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetProductByIdQuery(string id) : IRequest<ProductResponseDto>
    {
        // private readonly string Id = Id;
        public string Id { get; set; } = id;
    }
}
