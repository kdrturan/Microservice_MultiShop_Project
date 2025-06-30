using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
