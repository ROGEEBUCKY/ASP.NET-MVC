using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.App_Start
    {
    public class MappingProfile : Profile
        {
        public MappingProfile()
            {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();
            }
        }
    }