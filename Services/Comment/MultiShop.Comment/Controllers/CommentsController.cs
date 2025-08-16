using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Yorum eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.UserComments.Find(id);
            _context.UserComments.Remove(comment);
            _context.SaveChanges();
            return Ok("Yorum silindi.");
        }


        [HttpGet("get-by-productid")]
        public IActionResult GetByProductId(string productId)
        {
            var comments = _context.UserComments.Where(x => x.ProductId == productId).ToList();
            if (comments.Count == 0)
            {
                return NotFound("Bu ürüne ait yorum bulunamadı.");
            }
            return Ok(comments);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comment = _context.UserComments.Find(id);
            if (comment == null)
            {
                return NotFound("Yorum bulunamadı.");
            }
            return Ok(comment);
        }


        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum Güncellendi.");
        }

        [HttpGet("get-comments-count")]
        public IActionResult GetCommentsCount()
        {
            var comments = _context.UserComments.Count();
            if (comments == 0)
            {
                return NotFound("Aktif yorum bulunamadı.");
            }
            return Ok(comments);
        }
    }
}