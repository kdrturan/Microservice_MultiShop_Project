using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService:IProductDetailService
    {
        private readonly HttpClient _httpClient;


        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productDetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productDetails?id=" + id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productDetails");
            var jsondData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsondData);
            return values;
        }

        public async Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productDetails/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDetailDto>();
            return value;
        }

        public async Task<ResultProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productDetails/get-by-productid?id=" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<ResultProductDetailDto>();
            return value;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productDetails", updateProductDetailDto);
        }
    }
}
