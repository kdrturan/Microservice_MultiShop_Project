using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task DeleteCategoryAsync(string id);
    }
}
