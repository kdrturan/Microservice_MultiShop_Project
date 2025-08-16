using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticService.CommentStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentStatisticService _commentStatisticService;
        public _AdminLayoutHeaderComponentPartial(IMessageService messageService, IUserService userService, ICommentStatisticService commentStatisticService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentStatisticService = commentStatisticService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            int messageCount = await _messageService.GetTotalMessageCountByRecieverIdAsync(user.Id);
            var commentCount = await _commentStatisticService.GetCommentCountAsync();

            ViewBag.messageCount = messageCount;
            ViewBag.commentCount = commentCount;

            return View();
        }
    }
}
