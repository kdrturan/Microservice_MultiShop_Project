using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<UpdateProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<ResultProductDetailDto> GetByProductIdProductDetailAsync(string id);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task DeleteProductDetailAsync(string id);
    }
}
