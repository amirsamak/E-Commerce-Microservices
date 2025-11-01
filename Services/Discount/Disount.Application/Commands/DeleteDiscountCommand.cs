using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Application.Commands
{
    public class DeleteDiscountCommand(string productName) : IRequest<bool>
    {
        public string ProductName { get; set; } = productName;
    }
}
