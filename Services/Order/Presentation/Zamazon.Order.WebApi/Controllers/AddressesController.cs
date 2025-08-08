using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Order.Application.Features.CQRS.Commands.AddressCommands;
using Zamazon.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Zamazon.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace Zamazon.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly GetAddressQueryHandler _getAddressQueryCommandHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
        public AddressesController(
                       GetAddressByIdQueryHandler getAddressByIdQueryHandler,
                                  GetAddressQueryHandler getAddressQueryCommandHandler,
                                             CreateAddressCommandHandler createAddressCommandHandler,
                                                        UpdateAddressCommandHandler updateAddressCommandHandler,
                                                                   RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _getAddressQueryCommandHandler = getAddressQueryCommandHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressByIdAsync(int id)
        {
            var result = await _getAddressByIdQueryHandler.HandleAsync(new GetAddressByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAddressesAsync()
        {
            var result = await _getAddressQueryCommandHandler.HandleAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddressAsync([FromBody] CreateAddressCommand command)
        {
            
            await _createAddressCommandHandler.HandleAsync(command);
            return Ok(new { message = "Address created successfully." });
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddressAsync([FromBody] UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.HandleAsync(command);
            return Ok(new { message = "Address updated successfully." });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAddressAsync(int id)
        {
            await _removeAddressCommandHandler.HandleAsync(new RemoveAddressCommand(id));
            return Ok(new { message = "Address removed successfully." });
        }
    }
}
