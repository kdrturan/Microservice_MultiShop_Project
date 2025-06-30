using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.ProductListViewComponents
{
    public class _ProductListGetProductCountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int productCount)
        {
            ViewBag.ProductCount = productCount;
            return View();
        }
    }
}
