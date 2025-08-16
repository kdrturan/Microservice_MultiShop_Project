using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDtos>> GetOrderingByUserId(string id)
        {
            var responseMessage = _httpClient.GetAsync("orderings/get-ordering-byuserid?id="+ id);
            var jsonData = await responseMessage.Result.Content.ReadAsStringAsync();
            var  values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDtos>>(jsonData);
            return values;
        }
    }
}
