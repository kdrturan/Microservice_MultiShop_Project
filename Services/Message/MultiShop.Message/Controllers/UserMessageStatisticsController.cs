using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageStatisticsController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;
        public UserMessageStatisticsController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMessageCountAsync()
        {
            var values = await _userMessageService.GetTotalMessageCount();
            if (values > 0)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("No messages found.");
            }
        }
    }
}
