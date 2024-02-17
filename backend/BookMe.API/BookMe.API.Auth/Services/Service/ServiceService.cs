﻿using AutoMapper;
using BookMe.API.Auth.Models.Service;
using BookMe.API.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookMe.API.Auth.Services.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ApplicationContext _applicationContext;

        public ServiceService(IMapper mapper, IUserService userService , ApplicationContext applicationContext)
        {
            _mapper = mapper;
            _userService = userService;
            _applicationContext = applicationContext;   
        }
        public async Task<Entities.Service> CreateAsync(Guid userId, ServiceCreationViewModel serviceCreation)
        {
            var user = await _userService.GetAsync(userId);

            if(user == null)
            {
                // Make custom exceptions
                throw new InvalidOperationException();
            }

            var service = _mapper.Map<Entities.Service>(serviceCreation);

            if(service  == null)
            {
                throw new InvalidOperationException();  
            }

            user.Services.Add(service);
            if (_applicationContext.SaveChanges() == 0) 
            {
                throw new Exception();
            }

            return service;

        }

        public async Task<IEnumerable<Entities.Service>> ListAsync(Guid userId)
        {
            return await _applicationContext.Service.ToListAsync();
        }
    }
}
