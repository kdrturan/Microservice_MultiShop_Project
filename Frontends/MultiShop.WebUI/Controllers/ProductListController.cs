using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            var acceptHeader = HttpContext.Request.Headers["Accept"].ToString();
            if (!acceptHeader.Contains("text/html"))
            {
                return NotFound();
            }

            ViewBag.x = id;
            return View();
        }
    }
}
