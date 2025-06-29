using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
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
        public async Task<IActionResult> GetAllDiscountCoupons()
        {
            var result = await _discountService.GetAllDiscountCouponsAsync();
            return Ok(result);
        }

        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetDiscountCouponById(int couponId)
        {
            var result = await _discountService.GetDiscountCouponByIdAsync(couponId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Kupon Oluşturuldu.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {

            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("Kupon Güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int couponId)
        {
            await _discountService.DeleteDiscountCouponAsync(couponId);
            return Ok("Kupon Silindi.");
        }

      
    }
}
