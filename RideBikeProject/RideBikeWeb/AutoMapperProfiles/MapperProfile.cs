using AutoMapper;
using RideBikeProjectBLL.DTO;
using RideBikeWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RideBikeWeb.AutoMapperProfiles
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<UserViewModel, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();
            //.ForMember(x => x.Age, y => y.Ignore())
            //.ForMember(x => x.ConfirmPassword, y => y.MapFrom(z => z.Email));

            CreateMap<TeamViewModels, TeamDTO>();
            CreateMap<TeamDTO, TeamViewModels>();

        }
    }
}