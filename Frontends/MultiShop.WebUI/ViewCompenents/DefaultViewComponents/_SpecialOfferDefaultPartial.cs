using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewCompenents.DefaultViewComponents
{
    public class _SpecialOfferDefaultPartial:ViewComponent
    {
       private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferDefaultPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v0 = "Özel Teklif İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Tekliflker";
            ViewBag.v3 = "Özel Teklif Listesi";

            var values =  await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
