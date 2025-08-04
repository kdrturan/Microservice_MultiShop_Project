using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;
        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }


        void SetViewBagForOfferDiscount()
        {
            ViewBag.v0 = "İndirim Teklifi İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklifi Listesi";
        }


        public async Task<IActionResult> Index()
        {

            SetViewBagForOfferDiscount();
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            SetViewBagForOfferDiscount();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }


        [Route("{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            SetViewBagForOfferDiscount();
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
        }

        [Route("{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
