using AutoMapper;
using Common.DTO.Responses;
using Server.RequestResponse.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.AutoMapper.Profiles
{
    internal class SignUpMapperConfiguration : Profile
    {
        public SignUpMapperConfiguration()
        {
            CreateMap<SignUpResponse, SignUpResponseDTO>().ReverseMap();
        }
    }
}
