using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
