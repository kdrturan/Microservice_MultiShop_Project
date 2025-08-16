
namespace MultiShop.WebUI.Services.StatisticService.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCommentCountAsync()
        {
            var response = await _httpClient.GetAsync("comments/get-comments-count");
            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }
    }
}
