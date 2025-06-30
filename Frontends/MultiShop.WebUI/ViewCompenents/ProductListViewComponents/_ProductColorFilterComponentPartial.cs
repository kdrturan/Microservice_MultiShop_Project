using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.ProductListViewComponents
{
    public class _ProductColorFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
