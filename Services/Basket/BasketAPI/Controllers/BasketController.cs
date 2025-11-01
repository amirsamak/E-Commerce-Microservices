using Basket.Application.Commands;
using Basket.Application.GrpcServices;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController(IMediator mediator) : BaseApiController
    {
        private readonly IMediator _mediator = mediator;
        

        //[HttpGet("{userName}", Name = "GetBasket")]
        [HttpGet]
        [Route("[action]/{userName}", Name = "GetBasketByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartResponseDTO>> GetBasketByUserName(string userName)
        {
            var query = new GetBasketByUserNameQuery(userName);
            var basket = await _mediator.Send(query);
            return Ok(basket);
        }

        [HttpPost]
        [Route("[action]", Name = "UpdateBasket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartResponseDTO>> UpdateBasket([FromBody] CreateShoppingCartCommand command)
        {

          
            var updatedBasket = await _mediator.Send(command);
            return Ok(updatedBasket);
        }


        [HttpDelete]
        [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartResponseDTO>> DeleteBasketByUserName(string userName)
        {
            var command = new DeleteBasketByUserNameCommand(userName);
            var basket = await _mediator.Send(command);
            return Ok(basket);
        }
    }
}

    
