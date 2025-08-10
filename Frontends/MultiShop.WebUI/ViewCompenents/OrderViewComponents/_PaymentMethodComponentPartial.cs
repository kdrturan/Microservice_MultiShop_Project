using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.OrderViewComponents
{
    public class _PaymentMethodComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
