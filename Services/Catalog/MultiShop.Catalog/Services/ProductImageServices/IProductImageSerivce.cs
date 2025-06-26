using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageImageServices
{
    public interface IProductImageSerivce
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task DeleteProductImageAsync(string id);
    }
}
