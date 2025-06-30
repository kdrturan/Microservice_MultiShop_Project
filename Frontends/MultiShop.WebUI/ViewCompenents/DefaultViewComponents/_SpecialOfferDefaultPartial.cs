using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.DefaultViewComponents
{
    public class _SpecialOfferDefaultPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
