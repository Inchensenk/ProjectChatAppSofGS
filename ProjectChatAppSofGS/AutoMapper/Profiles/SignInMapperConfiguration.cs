using AutoMapper;
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
    /// Конфигурация для маппинга входа в аккаунт
    /// </summary>
    public class SignInMapperConfiguration : Profile
    {
        public SignInMapperConfiguration()
        {
            CreateMap<SignInRequest, SignInRequestDTO>().ReverseMap();
            CreateMap<SignInResponseDTO, SignInResponse>().ReverseMap();
        }
    }
}
