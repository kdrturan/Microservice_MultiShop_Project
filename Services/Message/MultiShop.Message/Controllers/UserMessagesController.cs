using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMessageCoupons()
        {
            var result = await _userMessageService.GetAllMessageAsync();
            return Ok(result);
        }

        [HttpGet("inbox")]
        public async Task<IActionResult> GetInboxMessage(string id)
        {
            var result = await _userMessageService.GetInboxMessageAsync(id);
            return Ok(result);
        }

        [HttpGet("sendbox")]
        public async Task<IActionResult> GetSendboxMessage(string id)
        {
            var result = await _userMessageService.GetSendboxMessageAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var result = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            if (createMessageDto == null)
            {
                return BadRequest("Geçersiz Bilgi.");
            }
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj başarıyla eklendi.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            if (updateMessageDto == null)
            {
                return BadRequest("Geçersiz Bilgi.");
            }
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj başarıyla gncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz bilgi.");
            }
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj başarıyla silindi.");
        }

        [HttpGet("totalcount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var result = await _userMessageService.GetTotalMessageCount();
            return Ok(result);
        }

        [HttpGet("totalcountbyrecieverid")]
        public async Task<IActionResult> GetTotalMessageCountByRecieverId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Geçersiz bilgi.");
            }
            var result = await _userMessageService.GetTotalMessageCountByRecieverId(id);
            return Ok(result);
        }
    }
}
