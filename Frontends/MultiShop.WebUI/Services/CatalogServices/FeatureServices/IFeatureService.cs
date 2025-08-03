using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeaturesDto);
        Task CreateFeatureAsync(CreateFeatureDto createFeaturesDto);
        Task DeleteFeatureAsync(string id);
    }
}
