namespace MultiShop.WebUI.Services.StatisticService.CommentStatisticServices
{
    public interface ICommentStatisticService
    {
        Task<int> GetCommentCountAsync();
    }
}
