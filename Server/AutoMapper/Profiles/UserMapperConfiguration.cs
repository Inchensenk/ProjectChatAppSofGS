using AutoMapper;
using Common.DTO;
using Server.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AutoMapper.Profiles
{
    /// <summary>
    /// Конфигурация маппинга пользователя
    /// </summary>
    public class UserMapperConfiguration : Profile
    {
        /*В методе CreateMap первый параметр: откуда маппит, а второй: куда маппить. 
         *Метод ReverseMap() позволяет маппить в обратную сторону при необходимости*/
        public UserMapperConfiguration()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
