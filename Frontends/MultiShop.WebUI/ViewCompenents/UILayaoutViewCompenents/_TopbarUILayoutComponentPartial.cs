using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.UILayaoutViewCompenents
{
    public class _TopbarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
