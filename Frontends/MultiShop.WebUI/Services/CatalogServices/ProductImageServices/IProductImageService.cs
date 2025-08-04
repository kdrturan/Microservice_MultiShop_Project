using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task<UpdateProductImageDto> GetByIdProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByProductIdProductImagesAsync(string id);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task DeleteProductImageAsync(string id);
    }
}
