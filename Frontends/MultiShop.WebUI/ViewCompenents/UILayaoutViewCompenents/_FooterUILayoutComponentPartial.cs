using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.ViewCompenents.UILayaoutViewCompenents
{
    public class _FooterUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            string token = "";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "client_id", "MultiShopVisitorClient" },
                        { "client_secret", "MultiShopSecret" },
                        { "grant_type", "client_credentials" }
                    })
                };

                using (var responses = await httpClient.SendAsync(request))
                {
                    if (responses.IsSuccessStatusCode)
                    {
                        var content = await responses.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);
                        token = tokenResponse["access_token"].ToString();
                    }
                }

            }



            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("https://localhost:7206/api/Abouts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View();
            }
            return View();
        }
    }
}
