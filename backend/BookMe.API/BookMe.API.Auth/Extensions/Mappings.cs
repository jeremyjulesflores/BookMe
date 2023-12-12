using AutoMapper;
using BookMe.API.Auth.Entities;
using BookMe.API.Auth.Models;

namespace BookMe.API.Auth
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<User, CreationViewModel>();
            CreateMap<CreationViewModel, User>();
        }
    }
}