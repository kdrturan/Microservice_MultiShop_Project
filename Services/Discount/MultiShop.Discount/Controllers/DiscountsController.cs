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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var result = await _discountService.GetDiscountCouponByIdAsync(id);
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



        [HttpGet("getcouponbycode")]
        public async Task<IActionResult> GetDiscountCouponById(string code)
        {
            var result = await _discountService.GetCodeDetailByCodeAsync(code);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpGet("get-coupouns-count")]
        public async Task<IActionResult> GetActiveDiscountCouponsCount(string code)
        {
            var result = await _discountService.GetActiveDiscountCouponsCountAsync();
            return Ok(result);
        }
    }
}
