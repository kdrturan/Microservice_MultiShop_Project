using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var response = await _httpClient.GetAsync("usermessages/inbox?id=" + id);
            var values = await response.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var response = await _httpClient.GetAsync($"usermessages/sendbox?id={id}");
            var values = await response.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
            return values;
        }

        public async Task<int> GetTotalMessageCountByRecieverIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"usermessages/totalcountbyrecieverid?id={id}");
            var values = await response.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
