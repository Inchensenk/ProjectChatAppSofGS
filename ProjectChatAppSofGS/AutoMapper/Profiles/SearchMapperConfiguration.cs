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
    /// Конфигурация для маппинга поиска
    /// </summary>
    public class SearchMapperConfiguration : Profile
    {
        public SearchMapperConfiguration()
        {
            CreateMap<SearchRequest, SearchRequestDTO>().ReverseMap();
            CreateMap<SearchResponse, UserSearchResponseDTO>().ReverseMap();
        }
    }
}
