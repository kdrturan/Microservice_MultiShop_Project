using MultiShop.DtoLayer.CargoDtos.CargoCustomerDetos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargoCustomers/GetCargoCustomerById?id=" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByIdDto>();
            return value;
        }
    }
}
