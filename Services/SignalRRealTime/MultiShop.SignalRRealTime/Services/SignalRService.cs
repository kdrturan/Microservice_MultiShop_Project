
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.SignalRRealTime.Services
{
    public class SignalRService : ISignalRService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetCommentCountAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7210/api/CommentStatistics");
            var jsonData = await response.Content.ReadAsStringAsync();
            var commentCount = JsonConvert.DeserializeObject<int>(jsonData);
            return commentCount;
        }

        public Task<int> GetTotalMessageCountByRecieverIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> GetTotalMessageCountByRecieverIdAsync(string id)
        //{
        //    var response = await _httpClient.GetAsync($"usermessages/totalcountbyrecieverid?id={id}");
        //    var values = await response.Content.ReadFromJsonAsync<int>();
        //    return values;
        //}
    }
}
