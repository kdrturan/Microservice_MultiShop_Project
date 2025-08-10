using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
           string query = "insert into Coupons (Code,Rate,isActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
           var paramaters = new DynamicParameters();
           paramaters.Add("code", createCouponDto.Code);
           paramaters.Add("rate", createCouponDto.Rate);
           paramaters.Add("isActive", createCouponDto.isActive);
           paramaters.Add("validDate", createCouponDto.ValidDate);
           using (var connection = _context.CreateConnection())
           {
                await connection.ExecuteAsync(query, paramaters);
           }
        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "delete from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", couponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            string query = "select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return result.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "select * from Coupons where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("code", code);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return result;
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetDiscountCouponByIdAsync(int couponId)
        {
            string query = "select * from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", couponId);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return result;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "update  Coupons Set Code=@code,Rate=@rate,isActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("code", updateCouponDto.Code);
            parameters.Add("rate", updateCouponDto.Rate);
            parameters.Add("isActive", updateCouponDto.isActive);
            parameters.Add("validDate", updateCouponDto.ValidDate);
            parameters.Add("couponId", updateCouponDto.CouponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
