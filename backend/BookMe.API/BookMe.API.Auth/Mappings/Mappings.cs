using AutoMapper;
using BookMe.API.Auth.Entities;
using BookMe.API.Auth.Models;
using BookMe.API.Auth.Models.Service;

namespace BookMe.API.Auth
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<User, CreationViewModel>();
            CreateMap<CreationViewModel, User>();

            CreateMap<Service, ServiceCreationViewModel>();
            CreateMap<ServiceCreationViewModel, Service>();
        }
    }
}