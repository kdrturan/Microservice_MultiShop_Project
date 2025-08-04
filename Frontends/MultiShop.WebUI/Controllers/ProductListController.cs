using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            ViewBag.directory1 = "Anasayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Ürün Listesi";
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.directory1 = "Anasayfa";
            ViewBag.directory2 = "Ürün Listesi";
            ViewBag.directory3 = "Ürün Detayları";

            var acceptHeader = HttpContext.Request.Headers["Accept"].ToString();
            if (!acceptHeader.Contains("text/html"))
            {
                return NotFound();
            }

            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment(string id)
        {

            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createComment)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createComment);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7206/api/Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
