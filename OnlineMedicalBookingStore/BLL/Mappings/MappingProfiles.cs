using AutoMapper;
using Common.ViewModels;
using DAL.Model;

namespace BLL.Mappings
    {
    public class MappingProfiles : Profile
        {
        public MappingProfiles()
            {
            Mapper.CreateMap<User, UserVM>().ReverseMap();
            Mapper.CreateMap<Role, RoleVM>().ReverseMap();
            Mapper.CreateMap<Message, MessageVM>().ReverseMap();
            Mapper.CreateMap<Product, ProductVM>().ReverseMap();
            Mapper.CreateMap<Remark, RemarkVM>().ReverseMap();
            Mapper.CreateMap<Cart, CartVM>().ReverseMap();
            Mapper.CreateMap<Orders, OrderVM>().ReverseMap();
            Mapper.CreateMap<OrderDetails, OrderDetailsVM>().ReverseMap();
            }
        }
    }
