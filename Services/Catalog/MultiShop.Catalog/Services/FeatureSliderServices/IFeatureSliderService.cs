using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task FeatureSliderStatusTrue(string id);
        Task FeatureSliderStatusFalse(string id);
    }
}
