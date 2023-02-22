using AutoMapper;
using Client.Models;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.AutoMapper.Profiles
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

            CreateMap<User, int>().ConvertUsing(sourse=> sourse.Id);
        }
    }
}
