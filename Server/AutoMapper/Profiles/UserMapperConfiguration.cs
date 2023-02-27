using AutoMapper;
using Common.DTO;
using Common.DTO.Requests;
using Common.DTO.Responses;
using Server.EFCore.Entities;
using Server.RequestResponse.Responses;
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
            CreateMap<User, SignUpRequestDTO>().ReverseMap();
            CreateMap<UserSearchResponse, UserSearchResponseDTO>().ReverseMap();
            CreateMap<int, User>().ForMember(dest => dest.Id, exp => exp.MapFrom(integ => integ.GetHashCode()));
        }
    }
}
