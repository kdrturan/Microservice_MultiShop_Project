using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;

namespace MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentStatisticsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsCountAsync()
        {
            int values = await _context.UserComments.CountAsync();
            if (values > 0)
            {
                return Ok(values);
            }
            else
            {
                return NotFound("No comments found.");
            }
        }
    }
}
