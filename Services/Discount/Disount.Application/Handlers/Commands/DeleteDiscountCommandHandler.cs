using Disount.Application.Commands;
using Disount.Application.Handlers.Queries;
using Disount.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disount.Application.Handlers.Commands
{
    public class DeleteDiscountCommandHandler(IDiscountRepository discountRepository, ILogger<DeleteDiscountCommandHandler> logger) : IRequestHandler<DeleteDiscountCommand, bool>
    {
        private readonly IDiscountRepository _discountRepository = discountRepository;
        private readonly ILogger<DeleteDiscountCommandHandler> _logger = logger;
        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            return await _discountRepository.DeleteDiscount(request.ProductName);
        }
    }
}
