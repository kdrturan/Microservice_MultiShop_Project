using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await  _discountService.GetDiscountCode(code);

            var basketValues = await _basketService.GetBasketTotal();
            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 10;
            var totalPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax * values.Rate / 100);
            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values.Rate, totalPriceWithDiscount = totalPriceWithDiscount });
        }

        [HttpGet]
        public IActionResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }
    }
}
