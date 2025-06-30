using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.UILayaoutViewCompenents
{
    public class _HeadUILayoutCompenentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
