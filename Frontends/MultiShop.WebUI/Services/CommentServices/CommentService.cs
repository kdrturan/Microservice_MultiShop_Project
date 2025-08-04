using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService:ICommentService
    {
        private readonly HttpClient _httpClient;


        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> CommentListByProductId(string productId)
        {
            var responseMessage = await _httpClient.GetAsync("comments/get-by-productid?productId=" + productId);
            var jsondData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsondData);
            return values;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync("comments?id=" + id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var responseMessage = await _httpClient.GetAsync("comments");
            var jsondData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsondData);
            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("comments/" + id);
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return value;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
        }
    }
}
