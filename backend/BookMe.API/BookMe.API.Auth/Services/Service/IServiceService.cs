using BookMe.API.Auth.Entities;
using BookMe.API.Auth.Models.Service;

namespace BookMe.API.Auth.Services.Service
{
    public interface IServiceService
    {
        public Task<IEnumerable<Entities.Service>> ListAsync(Guid userId);
        public Task<Entities.Service> CreateAsync(Guid userId, ServiceCreationViewModel serviceCreation); 
    }
}
