using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Order.Application.Features.MediatR.Commands;
using Zamazon.Order.Application.Features.MediatR.Queries;

namespace Zamazon.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            
            var result = await _mediator.Send(new GetOrderByIdQuery(id));
            
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            
            var result = await _mediator.Send(new GetOrderQuery());
            
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            

            await _mediator.Send(command);
            return Ok("Order Created Successfully"); 
                
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            

            await _mediator.Send(command);
            return Ok("Order Updated Successfully");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            
            await _mediator.Send(new RemoveOrderCommand(id));
            return Ok("Order Deleted Successfully");
        }
    }
}
