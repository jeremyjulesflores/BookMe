using BookMe.API.Auth.Entities;

namespace BookMe.API.Auth.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<Entities.User> GetAsync(Guid id);
        Task<Entities.User> GetByEmailAsync(string email);
        Task<Guid> AddAsync(Models.CreationViewModel user);
        Task<bool> UpdateAsync(Entities.User user);
        //Task<bool> UpdatePasswordAsync(Guid id, string password, string salt);
        Task<bool> DeleteAsync(Guid id);
    }
}
