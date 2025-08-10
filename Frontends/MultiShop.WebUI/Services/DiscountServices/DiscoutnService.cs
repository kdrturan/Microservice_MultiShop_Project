using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscoutnService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscoutnService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var response = await _httpClient.GetAsync($"discounts/getcouponbycode?code={code}");
            var values = await response.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
            return values;
        }
    }
}
