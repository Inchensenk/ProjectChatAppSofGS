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
    /// Конфигурация маппинга сообщения
    /// </summary>
    public class MessageMapperConfiguration : Profile
    {
        public MessageMapperConfiguration() 
        {
            /*В методе CreateMap первый параметр: откуда маппит, а второй: куда маппить. 
             *Метод ReverseMap() позволяет маппить в обратную сторону при необходимости*/
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<SendMessageRequestDTO, SendMessageRequest>().ReverseMap();
            CreateMap<SendMessageResponse, SendMessageResponseDTO>().ReverseMap();
            CreateMap<ReadMessagesRequest, ReadMessagesRequestDTO>().ReverseMap();
            CreateMap<DeleteMessageRequest, DeleteMessageRequestDTO>().ReverseMap();
        }
    }
}
