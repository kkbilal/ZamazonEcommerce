using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Basket.WebApi.Dtos;
using Zamazon.Basket.WebApi.LoginServices;
using Zamazon.Basket.WebApi.Services;

namespace Zamazon.Basket.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var user = User.Claims;
            var basket = await _basketService.GetBasket(_loginService.GetUserId);
            if (basket == null)
            {
                return NotFound();
            }
            return Ok(basket);
        }
        [HttpPost]
        public async Task<IActionResult> SaveBasket([FromBody] BasketTotalDto basketTotalDto)
        {
            if (basketTotalDto == null || string.IsNullOrEmpty(basketTotalDto.UserId))
            {
                return BadRequest("Invalid basket data.");
            }
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Basket Saved Successfully");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Basket Deleted Successfully");
        }
    }
}
