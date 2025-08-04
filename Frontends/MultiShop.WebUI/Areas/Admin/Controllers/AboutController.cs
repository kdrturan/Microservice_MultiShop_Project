using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }


        void SetViewBagForAbout()
        {
            ViewBag.v0 = "Hakkımızda İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Listesi";
        }


        public async Task<IActionResult> Index()
        {

            SetViewBagForAbout();
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            SetViewBagForAbout();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }


        [Route("{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });

        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            SetViewBagForAbout();
            var values = await _aboutService.GetByIdAboutAsync(id);
            return View(values);
        }

        [Route("{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}

