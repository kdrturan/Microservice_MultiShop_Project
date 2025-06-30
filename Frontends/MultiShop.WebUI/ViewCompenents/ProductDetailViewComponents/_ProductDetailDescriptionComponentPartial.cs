using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
