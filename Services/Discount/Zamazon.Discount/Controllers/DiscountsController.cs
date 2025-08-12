using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zamazon.Discount.Dtos;
using Zamazon.Discount.Services;

namespace Zamazon.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDiscountCoupons()
        {
            var result = await _discountService.GetCouponsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDiscountCoupon(int id)
        {
            var result = await _discountService.GetByIdCouponAsync(id);
            
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateCouponDto createCouponDto)
        {
            
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon created successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        { 
            await _discountService.DeleteCouponAsync(id);
            return Ok("Coupon deleted successfully.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponDto updateCouponDto)
        {
            
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon updated successfully.");
        }

    }
}
