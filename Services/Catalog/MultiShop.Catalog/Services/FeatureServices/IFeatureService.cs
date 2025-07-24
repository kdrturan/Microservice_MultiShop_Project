using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeaturesDto);
        Task CreateFeatureAsync(CreateFeatureDto createFeaturesDto);
        Task DeleteFeatureAsync(string id);
    }
}
