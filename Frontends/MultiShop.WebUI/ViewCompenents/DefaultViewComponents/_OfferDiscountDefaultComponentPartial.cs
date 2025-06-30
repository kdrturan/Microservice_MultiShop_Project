using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
