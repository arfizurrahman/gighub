using AutoMapper;
using GigHubApp.Controllers.Api;
using GigHubApp.Dtos;
using GigHubApp.Models;

namespace GigHubApp
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}