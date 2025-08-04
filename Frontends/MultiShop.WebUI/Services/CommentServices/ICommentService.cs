using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> CommentListByProductId(string productId);
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<UpdateCommentDto> GetByIdCommentAsync(string id);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentsDto);
        Task CreateCommentAsync(CreateCommentDto createCommentsDto);
        Task DeleteCommentAsync(string id);
    }
}
