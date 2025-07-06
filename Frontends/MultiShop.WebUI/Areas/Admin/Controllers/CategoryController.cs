﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";



            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7206/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }


            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7206/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new {area = "Admin"});
            }
            return View();
        }


        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7206/api/Categories?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v0 = "Kategori İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7206/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7206/api/Categories/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
