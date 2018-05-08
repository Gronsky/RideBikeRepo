using AutoMapper;
using Infrastructure.DTO;
using Infrastructure.Models;
using RideBikeProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Infrastructure
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

            CreateMap<EventViewModels, EventDTO>();
            CreateMap<EventDTO, EventViewModels>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Team, TeamDTO>();
            CreateMap<TeamDTO, Team>();

            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();

            CreateMap<Bike, BikeDTO>();
            CreateMap<BikeDTO, Bike>();
        }
    }
}