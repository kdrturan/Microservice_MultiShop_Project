using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task<GetByIdBrandDto> GetByIdBrandAsync(string id);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandsDto);
        Task CreateBrandAsync(CreateBrandDto createBrandsDto);
        Task DeleteBrandAsync(string id);
    }
}
