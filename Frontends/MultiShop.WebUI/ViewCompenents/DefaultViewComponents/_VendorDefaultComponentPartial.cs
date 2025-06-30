using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
