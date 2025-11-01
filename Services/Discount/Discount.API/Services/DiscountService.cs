using Discount.Grpc.Protos;
using Disount.Application.Commands;
using Disount.Application.Queries;
using Grpc.Core;
using MediatR;

namespace Discount.API.Services
{
    public class DiscountService(IMediator mediator) : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IMediator mediator = mediator;

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var query = new GetDiscountQuery(request.ProductName);
            return await mediator.Send(query);
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var command = new CreateDiscountCommand
            {
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };
            return await mediator.Send(command);
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var command = new UpdateDiscoutCommand
            {
                Id = request.Coupon.Id,
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };
            return await mediator.Send(command);
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var command = new DeleteDiscountCommand(request.ProductName);
            var result = await mediator.Send(command);
            return new DeleteDiscountResponse { Success = result };
        }
    }
}
