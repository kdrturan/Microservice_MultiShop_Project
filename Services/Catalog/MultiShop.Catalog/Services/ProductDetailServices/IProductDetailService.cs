using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task DeleteProductDetailAsync(string id);
    }
}
