using AutoMapper;
using Client.Models;
using Client.RequestResponse.Requests;
using Client.RequestResponse.Responses;
using Common.DTO;
using Common.DTO.Requests;
using Common.DTO.Responses;
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
        /*В методе CreateMap первый параметр: откуда маппит, а второй: куда маппить. 
         *Метод ReverseMap() позволяет маппить в обратную сторону при необходимости*/
        public ConversationMapperConfiguration() 
        {


            CreateMap<Conversation, ConversationDTO>().ReverseMap();

            CreateMap<Conversation, CreateConversationRequestDTO>().ForMember(dest => dest.UsersId, exp => exp.MapFrom(conversation => conversation.UserListingСonversationalist))
                                                                   .ReverseMap();

            CreateMap<CreateConversationResponse, CreateConversationResponseDTO>().ReverseMap();

            CreateMap<Conversation, CreateConversationResponse>().ForMember(dest => dest.ConversationId, exp => exp.MapFrom(conversation => conversation.Id))
                                                                 .ForMember(dest => dest.MessageId, exp => exp.MapFrom(Conversation => Conversation.MessageListing.First().Id))
                                                                 .ReverseMap();

            CreateMap<ExtendedDeleteConversationRequest, ExtendedDeleteConversationRequestDTO>().ReverseMap();

            CreateMap<DeleteConversationRequestDTO, DeleteConversationRequest>().ReverseMap();

            CreateMap<ResponseDTO, Response>().ReverseMap();

        }
    }
}
