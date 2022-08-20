using AutoMapper;
using Common.ViewModels;
using DAL.Models;

namespace BLL.Mappings
    {
    public class MappingProfiles : Profile
        {
        public MappingProfiles()
            {
            Mapper.CreateMap<User, UserVM>().ReverseMap();
            Mapper.CreateMap<Role, RoleVM>().ReverseMap();
            Mapper.CreateMap<Duty, DutyVM>().ReverseMap();
            Mapper.CreateMap<Roster, RosterVM>().ReverseMap();
            Mapper.CreateMap<Category, CategoryVM>().ReverseMap();
            Mapper.CreateMap<DutyType, DutyTypeVM>().ReverseMap();
            Mapper.CreateMap<Message, MessageVM>().ReverseMap();
            Mapper.CreateMap<AssignedDuties, AssignedDutiesVM>().ReverseMap();
            Mapper.CreateMap<Request, RequestVM>().ReverseMap();
            }
        }
    }
