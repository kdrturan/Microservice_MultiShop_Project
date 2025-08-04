using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService:IProductImageService
    {
        private readonly HttpClient _httpClient;


        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productImages", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productImages?id=" + id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productImages");
            var jsondData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsondData);
            return values;
        }

        public async Task<UpdateProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productImages/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateProductImageDto>();
            return value;
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImagesAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productImages/get-by-productid?id=" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return value;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productImages", updateProductImageDto);
        }
    }
}
