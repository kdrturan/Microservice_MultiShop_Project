using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
