
using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShop.WebUI.Services.StatisticService.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            var response = await _httpClient.GetAsync("http://localhost:5001/api/statistics/user-count");
            var values = await response.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
