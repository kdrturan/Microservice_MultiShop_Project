using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressServices : IOrderAddressServices
    {
        private readonly HttpClient _httpClient;

        public OrderAddressServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateOrderAddressDto createAboutsDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("addresses", createAboutsDto);
        }
    }
}
