using AutoMapper;
using GigHubApp.Controllers.Api;
using GigHubApp.Core.Dtos;
using GigHubApp.Core.Models;

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