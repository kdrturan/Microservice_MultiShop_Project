using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task<UpdateBrandDto> GetByIdBrandAsync(string id);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandsDto);
        Task CreateBrandAsync(CreateBrandDto createBrandsDto);
        Task DeleteBrandAsync(string id);
    }
}
