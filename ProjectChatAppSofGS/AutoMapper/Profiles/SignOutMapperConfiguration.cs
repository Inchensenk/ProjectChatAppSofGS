using AutoMapper;
using Client.RequestResponse.Requests;
using Common.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.AutoMapper.Profiles
{
    /// <summary>
    /// Конфигурация для маппинга выхода из аккаунта
    /// </summary>
    public class SignOutMapperConfiguration : Profile
    {
        public SignOutMapperConfiguration()
        {
            CreateMap<SignOutRequest, SignOutRequestDTO>().ReverseMap();
        }
    }
}
