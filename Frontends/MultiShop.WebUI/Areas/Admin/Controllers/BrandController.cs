using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        void SetViewBagForBrand()
        {
            ViewBag.v0 = "Marka İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Listesi";
        }


        public async Task<IActionResult> Index()
        {

            SetViewBagForBrand();
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            SetViewBagForBrand();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }


        [Route("{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });

        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            SetViewBagForBrand();
            var values = await _brandService.GetByIdBrandAsync(id);
            return View(values);
        }

        [Route("{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
    }
}
