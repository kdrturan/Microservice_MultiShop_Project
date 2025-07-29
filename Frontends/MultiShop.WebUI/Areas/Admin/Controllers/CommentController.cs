using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Yorum İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi Listesi";




            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Comments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }


            return View();
        }

        [Route("{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7210/api/Comments?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v0 = "Hakkımızda İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımızdalar";
            ViewBag.v3 = "Hakkımızda Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Comments/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCommentDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7210/api/Comments/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
