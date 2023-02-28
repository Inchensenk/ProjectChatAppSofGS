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
    /// Конфигурация маппинга сообщения
    /// </summary>
    public class MessageMapperConfiguration : Profile
    {
        public MessageMapperConfiguration() 
        {
            /*В методе CreateMap первый параметр: откуда маппит, а второй: куда маппить. 
             *Метод ReverseMap() позволяет маппить в обратную сторону при необходимости*/
            CreateMap<Message, MessageDTO>().ReverseMap();

            CreateMap<SendMessageRequest, SendMessageRequestDTO>().ReverseMap();

            CreateMap<SendMessageResponseDTO, SendMessageResponse>().ReverseMap();

            CreateMap<ExtendedDeleteMessageRequest, ExtendedDeleteMessageRequestDTO>().ReverseMap();

            CreateMap<DeleteMessageRequestDTO, DeleteMessageRequest>().ReverseMap();

            CreateMap<ExtendedReadMessagesRequest, ExtendedReadMessagesRequestDTO>().ReverseMap();

            CreateMap<ReadMessagesRequestDTO,ReadMessagesRequest>().ReverseMap();
        }
    }
}
