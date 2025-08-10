using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.OrderViewComponents
{
    public class _OrderDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
