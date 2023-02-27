using AutoMapper;
using Client.Models;
using Common.DTO;
using Common.DTO.Requests;
using Common.DTO.Responses;
using Server.RequestResponse.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.AutoMapper.Profiles
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

            CreateMap<Conversation, CreateConversationRequestDTO>().ForMember(dest => dest.UsersId, exp => exp.MapFrom(conversation => conversation.UserListingСonversationalist)).ReverseMap();


            CreateMap<Conversation, CreateConversationResponse>().ForMember(dest => dest.ConversationId, exp => exp.MapFrom(dial => dial.Id))
                                                                 .ForMember(dest => dest.MessageId, exp => exp.MapFrom(dial => dial.MessageListing.First().Id)).ReverseMap();

        }
    }
}
