using Zamazon.Discount.Dtos;

namespace Zamazon.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetCouponsAsync();
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
    }
}
