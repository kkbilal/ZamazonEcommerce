using Dapper;
using Zamazon.Discount.Context;
using Zamazon.Discount.Dtos;

namespace Zamazon.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = @"INSERT INTO Coupons (Code, Rate, Status, ValidDate) 
                        VALUES (@code, @rate, @status, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@status", createCouponDto.Status);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = @"DELETE FROM Coupons WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = @"SELECT * FROM Coupons WHERE CouponId = @couponId";
                        
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameters);
                return value;
            }
        }

        public async Task<List<ResultCouponDto>> GetCouponsAsync()
        {
           string query = @"SELECT * FROM Coupons";
                        
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = @"UPDATE Coupons 
                        SET Code = @code, Rate = @rate, Status = @status, ValidDate = @validDate 
                        WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@status", updateCouponDto.Status);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
