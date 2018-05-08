using AutoMapper;
using RideBike.Infrastructure.DTO;
using RideBike.Infrastructure.Models;
using RideBikeProjectDAL.Entities;

namespace RideBike.Infrastructure
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<LoginViewModel, UserDTO>()
               .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
               .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
               .ForAllOtherMembers(z => z.Ignore());

            CreateMap<UserViewModel, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();
            //.ForMember(x => x.ConfirmPassword, y => y.MapFrom(z => z.Email));

            CreateMap<TeamViewModels, TeamDTO>();
            CreateMap<TeamDTO, TeamViewModels>();

            CreateMap<EventViewModels, EventDTO>();
            CreateMap<EventDTO, EventViewModels>();

            CreateMap<User, UserDTO>()
                .ForMember(x => x.Age, y => y.Ignore());
            CreateMap<UserDTO, User>()
                .ForMember(x => x.EmailConfirmed, y => y.Ignore())
                .ForMember(x => x.AccessFailedCount, y => y.Ignore())
                .ForMember(x => x.Claims, y => y.Ignore())
                .ForMember(x => x.LockoutEnabled, y => y.Ignore())
                .ForMember(x => x.LockoutEndDateUtc, y => y.Ignore())
                .ForMember(x => x.Logins, y => y.Ignore())
                .ForMember(x => x.PasswordHash, y => y.Ignore())
                .ForMember(x => x.PhoneNumber, y => y.Ignore())
                .ForMember(x => x.PhoneNumberConfirmed, y => y.Ignore())
                .ForMember(x => x.Roles, y => y.Ignore())
                .ForMember(x => x.SecurityStamp, y => y.Ignore())
                .ForMember(x => x.TwoFactorEnabled, y => y.Ignore())
                .ForMember(x => x.UserName, y => y.Ignore());


            CreateMap<Team, TeamDTO>()              
                .ForMember(x => x.Chief, y => y.Ignore())
                .ForMember(x => x.Image, y => y.Ignore());

            CreateMap<TeamDTO, Team>();

            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();

            CreateMap<Bike, BikeDTO>();
            CreateMap<BikeDTO, Bike>();
        }
    }
}