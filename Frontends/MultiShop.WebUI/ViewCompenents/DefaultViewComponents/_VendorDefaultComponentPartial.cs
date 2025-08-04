﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace MultiShop.WebUI.ViewCompenents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _VendorDefaultComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
    }
}
