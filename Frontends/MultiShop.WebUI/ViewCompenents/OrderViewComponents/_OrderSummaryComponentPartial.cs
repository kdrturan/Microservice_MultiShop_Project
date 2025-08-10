using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewCompenents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial:ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasketTotal();
            var basketItems = values.BasketItems;
            return View(basketItems);
        }
    }
}
