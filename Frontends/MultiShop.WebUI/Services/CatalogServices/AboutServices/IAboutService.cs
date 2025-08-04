using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<UpdateAboutDto> GetByIdAboutAsync(string id);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutsDto);
        Task CreateAboutAsync(CreateAboutDto createAboutsDto);
        Task DeleteAboutAsync(string id);
    }
}
