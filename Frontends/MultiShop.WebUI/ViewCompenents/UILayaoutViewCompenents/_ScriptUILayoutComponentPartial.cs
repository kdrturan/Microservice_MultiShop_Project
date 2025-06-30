using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.UILayaoutViewCompenents
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
