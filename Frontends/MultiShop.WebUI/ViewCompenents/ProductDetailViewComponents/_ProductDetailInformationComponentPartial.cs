using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
