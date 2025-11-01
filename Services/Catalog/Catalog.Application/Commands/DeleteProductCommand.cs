using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commands
{
    public class DeleteProductCommand(string id) : IRequest<bool>
    {
        public string Id { get; set; } = id;
    }
}
