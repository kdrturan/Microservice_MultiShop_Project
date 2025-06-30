using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.UILayaoutViewCompenents
{
    public class _FooterUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
