using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewCompenents.ContactViewComponents
{
    public class _ContactDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
