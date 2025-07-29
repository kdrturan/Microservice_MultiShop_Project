using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            if (createRegisterDto.ConfirmPassword == createRegisterDto.Password)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createRegisterDto);
                var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:5001/api/Registers", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            return View();
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}
