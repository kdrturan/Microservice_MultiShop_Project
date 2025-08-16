using AutoMapper;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Mapping
{
    public class GeneralMaping:Profile
    {
        public GeneralMaping()
        {
            CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
        }
    }
}
