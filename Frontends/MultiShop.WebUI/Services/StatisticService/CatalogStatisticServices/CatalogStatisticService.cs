
namespace MultiShop.WebUI.Services.StatisticService.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            var response = await _httpClient.GetAsync("statistics/brand-count");
            var count = await response.Content.ReadFromJsonAsync<long>();
            return count;
        }

        public async Task<long> GetCategoryCount()
        {
            var response = await _httpClient.GetAsync("statistics/category-count");
            var count = await response.Content.ReadFromJsonAsync<long>();
            return count;
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var response = await _httpClient.GetAsync("statistics/max-price-product-name");
            var value = await response.Content.ReadAsStringAsync();
            return value;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var response = await _httpClient.GetAsync("statistics/min-price-product-name");
            var value = await response.Content.ReadAsStringAsync();
            return value;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var response = await _httpClient.GetAsync("statistics/product-avg-price");
            var count = await response.Content.ReadFromJsonAsync<decimal>();
            return count;
        }

        public async Task<long> GetProductCount()
        {
            var response = await _httpClient.GetAsync("statistics/product-count");
            var count = await response.Content.ReadFromJsonAsync<long>();
            return count;
        }
    }
}
