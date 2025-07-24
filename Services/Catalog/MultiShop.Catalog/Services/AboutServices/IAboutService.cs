using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutsDto);
        Task CreateAboutAsync(CreateAboutDto createAboutsDto);
        Task DeleteAboutAsync(string id);
    }
}
