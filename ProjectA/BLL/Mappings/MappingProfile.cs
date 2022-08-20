using AutoMapper;
using Common;
using DAL.Models;

namespace BLL.Mappings
    {
    public class MappingProfile : Profile
        {
        public MappingProfile()
            {
            Mapper.CreateMap<Anime, AnimeDto>().ReverseMap();
            }
        }
    }
