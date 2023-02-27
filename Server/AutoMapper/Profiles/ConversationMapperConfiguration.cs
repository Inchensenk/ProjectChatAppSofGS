using AutoMapper;
using Common.DTO;
using Common.DTO.Requests;
using Common.DTO.Responses;
using Server.EFCore.Entities;
using Server.RequestResponse.Request;
using Server.RequestResponse.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AutoMapper.Profiles
{
    /// <summary>
    /// Конфигурация маппинга диалога
    /// </summary>
    public class ConversationMapperConfiguration : Profile
    {
        public ConversationMapperConfiguration() 
        {
            /*В методе CreateMap первый параметр: откуда маппит, а второй: куда маппить. 
             *Метод ReverseMap() позволяет маппить в обратную сторону при необходимости*/

            CreateMap<Conversation, ConversationDTO>().ReverseMap();

            CreateMap<Conversation, CreateConversationRequestDTO>().ForMember(d => d.UsersId, exp => exp.MapFrom(conversation => conversation.UserListinc));

            CreateMap<CreateConversationRequestDTO, Conversation>();

            CreateMap<CreateConversationResponse, CreateConversationResponseDTO>().ReverseMap();

            CreateMap<Conversation, CreateConversationResponse>().ForMember(dest => dest.ConversationId, exp => exp.MapFrom(dial => dial.Id))
                                                                 .ForMember(dest => dest.MessageId, exp => exp.MapFrom(conversation => conversation.MessageListinc.First().Id))
                                                                 .ReverseMap();

            CreateMap<DeleteConversationRequest, DeleteConversationRequestDTO>().ReverseMap();

            CreateMap<Response, ResponseDTO>().ReverseMap();
        }
    }
}
