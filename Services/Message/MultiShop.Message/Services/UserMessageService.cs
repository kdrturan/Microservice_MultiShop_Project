using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var mapped = _mapper.Map<UserMessage>(createMessageDto);
            await _context.UserMessages.AddAsync(mapped);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _context.UserMessages.FindAsync(id);
            if (value != null)
            {
                _context.Remove(value);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _context.UserMessages.ToListAsync();
            var mappped = _mapper.Map<List<ResultMessageDto>>(values);
            await _context.SaveChangesAsync();
            return mappped ?? new List<ResultMessageDto>();
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _context.UserMessages.FindAsync(id);
            var mappped = _mapper.Map<GetByIdMessageDto>(values);
            await _context.SaveChangesAsync();
            return mappped ?? new GetByIdMessageDto();
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _context.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            var mappped = _mapper.Map<List<ResultInboxMessageDto>>(values);
            await _context.SaveChangesAsync();
            return mappped ?? new List<ResultInboxMessageDto>();
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _context.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            var mappped = _mapper.Map<List<ResultSendboxMessageDto>>(values);
            await _context.SaveChangesAsync();
            return mappped ?? new List<ResultSendboxMessageDto>();
        }

        public async Task<int> GetTotalMessageCount()
        {
            var count = await _context.UserMessages.CountAsync();
            return count;
        }

        public async Task<int> GetTotalMessageCountByRecieverId(string id)
        {
            var count = await _context.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
            return count;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var values = _mapper.Map<UserMessage>(updateMessageDto);
            _context.UserMessages.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
