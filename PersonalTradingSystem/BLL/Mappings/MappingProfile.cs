using AutoMapper;
using Common.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappings
    {
    public class MappingProfile : Profile
        {
        public MappingProfile()
            {
            Mapper.CreateMap<User, UserVM>().ReverseMap();
            Mapper.CreateMap<Funds, FundsVM>().ReverseMap();
            Mapper.CreateMap<Investment, InvestmentVM>().ReverseMap();
            Mapper.CreateMap<FundRemark, FundRemarkVM>().ReverseMap();
            }
        }
    }
