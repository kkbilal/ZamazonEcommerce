using System.Text.Json;
using Zamazon.Basket.WebApi.Dtos;
using Zamazon.Basket.WebApi.Settings;

namespace Zamazon.Basket.WebApi.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
           var status =await _redisService.GetDatabase().KeyDeleteAsync(userId);
            
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var db = await _redisService.GetDatabase().StringGetAsync(userId);
            if (db.IsNullOrEmpty)
            {
                return null;
            }
            
            return JsonSerializer.Deserialize<BasketTotalDto>(db);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDatabase().StringSetAsync(basketTotalDto.UserId, 
                               JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
