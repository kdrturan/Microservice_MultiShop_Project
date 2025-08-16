using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("cargoCompanies", createCargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("cargoCompanies?id=" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("cargoCompanies");
            var jsondData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCargoCompanyDto>>(jsondData);
            return values;
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("cargoCompanies/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDto>();
            return value;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("cargoCompanies", updateCargoCompanyDto);
        }
    }
}
