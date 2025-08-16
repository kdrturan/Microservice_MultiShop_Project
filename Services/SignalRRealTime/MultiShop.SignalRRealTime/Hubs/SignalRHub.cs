using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTime.Services;

namespace MultiShop.SignalRRealTime.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ISignalRService _signalRService;

        public SignalRHub(ISignalRService signalRService)
        {
            _signalRService = signalRService;
        }


        public async Task SendStatisticCount()
        {
            var commentCount = await _signalRService.GetCommentCountAsync();
            await Clients.All.SendAsync("ReceiveCommentCount", commentCount);

            //var messageCount = await _signalRService.GetTotalMessageCountByRecieverIdAsync(id);
            //await Clients.All.SendAsync("ReceiveMessageCount", messageCount);
        }
    }
}
