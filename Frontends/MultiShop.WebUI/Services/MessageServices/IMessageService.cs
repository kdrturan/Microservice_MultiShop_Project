using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task<int> GetTotalMessageCountByRecieverIdAsync(string id);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int id);
    }
}
