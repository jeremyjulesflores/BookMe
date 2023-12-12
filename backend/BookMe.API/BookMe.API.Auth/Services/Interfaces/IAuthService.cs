namespace BookMe.API.Auth.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Authenticate User
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>JWT Token</returns>
        Task<string> Authenticate(string email, string password);
        //Task ChangePassword(Guid id, string newPassword);
    }
}
