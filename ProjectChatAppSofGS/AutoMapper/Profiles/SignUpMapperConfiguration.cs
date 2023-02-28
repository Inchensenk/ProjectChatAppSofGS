using AutoMapper;
using Client.Models;
using Client.RequestResponse.Requests;
using Client.RequestResponse.Responses;
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
    /// Конфигурация для маппинга Регистрации
    /// </summary>
    public class SignUpMapperConfiguration : Profile
    {
        public SignUpMapperConfiguration()
        {
            CreateMap<SignUpRequest, SignUpRequestDTO>().ReverseMap();
            CreateMap<SignUpRequest, User>().ReverseMap();
            CreateMap<SignUpResponse, SignUpResponseDTO>().ReverseMap();
        }
    }
}
