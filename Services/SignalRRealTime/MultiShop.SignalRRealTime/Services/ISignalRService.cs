namespace MultiShop.SignalRRealTime.Services
{
    public interface ISignalRService
    {
        Task<int> GetTotalMessageCountByRecieverIdAsync(string id);
        Task<int> GetCommentCountAsync();

    }
}
