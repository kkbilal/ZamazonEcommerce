using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Zamazon.Order.Application.Features.CQRS.Handlers.OrderDetailHandler;
using Zamazon.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace Zamazon.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailsByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler _getOrderDetailsQueryCommandHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailsCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailsCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailsCommandHandler;
        public OrderDetailsController(
                       GetOrderDetailByIdQueryHandler getOrderDetailsByIdQueryHandler,
                                  GetOrderDetailQueryHandler getOrderDetailsQueryCommandHandler,
                                             CreateOrderDetailCommandHandler createOrderDetailsCommandHandler,
                                                        UpdateOrderDetailCommandHandler updateOrderDetailsCommandHandler,
                                                                   RemoveOrderDetailCommandHandler removeOrderDetailsCommandHandler)
        {
            _getOrderDetailsByIdQueryHandler = getOrderDetailsByIdQueryHandler;
            _getOrderDetailsQueryCommandHandler = getOrderDetailsQueryCommandHandler;
            _createOrderDetailsCommandHandler = createOrderDetailsCommandHandler;
            _updateOrderDetailsCommandHandler = updateOrderDetailsCommandHandler;
            _removeOrderDetailsCommandHandler = removeOrderDetailsCommandHandler;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailByIdAsync(int id)
        {
            var result = await _getOrderDetailsByIdQueryHandler.HandleAsync(new GetOrderDetailByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderDetailsAsync()
        {
            var result = await _getOrderDetailsQueryCommandHandler.HandleAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetailAsync([FromBody] CreateOrderDetailCommand command)
        {
            await _createOrderDetailsCommandHandler.HandleAsync(command);
            return Ok(new { message = "Order detail created successfully." });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetailAsync([FromBody] UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailsCommandHandler.HandleAsync(command);
            return Ok(new { message = "Order detail updated successfully." });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderDetailAsync(int id)
        {
            await _removeOrderDetailsCommandHandler.HandleAsync(new RemoveOrderDetailCommand(id));
            return Ok(new { message = "Order detail removed successfully." });
        }

    }
}
