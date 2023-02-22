using AutoMapper;
using Client.Models;
using Common.DTO;
using Common.DTO.Requests;
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

            //CreateMap<Conversation, CreateConversationRequestDTO>().ForMember(d => d.UsersId, e => e.MapFrom(conversation => conversation.CurrentUser)
        }
    }
}
