using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Areas.Admin.Controllers;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewCompenents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Comments/get-by-productid?productId=" + id );
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }


            return View();
        }
    }
}
