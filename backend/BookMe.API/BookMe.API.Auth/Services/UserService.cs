using AutoMapper;
using BookMe.API.Auth.Entities;
using BookMe.API.Auth.Models;
using BookMe.API.Auth.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BookMe.API.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly int _keySize;
        private readonly int _iterations;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuratiom, ApplicationContext applicationContext, IMapper mapper)
        {
            this._applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            this._mapper = mapper;

            _keySize = configuratiom.GetValue<int>("KeySize");
            _iterations = configuratiom.GetValue<int>("Iterations");
        }

        public async Task<User?> GetAsync(Guid id)
        {
            return await _applicationContext.User.Include(u => u.Services).FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _applicationContext.User
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }


        public async Task<IEnumerable<User?>> ListAsync()
        {
            return await _applicationContext.User.ToListAsync();
        }


        public async Task<Guid> AddAsync(CreationViewModel userToCreate)
        {
            if (userToCreate == null)
            {
                throw new ArgumentNullException(nameof(userToCreate));
            }

            try
            {

                //Generate password hash and salt
                var hashAndSalt = await HashPasswordAsync(userToCreate.Password);
                
                var user = _mapper.Map<Entities.User>(userToCreate);
                
                //Assign hash and salt to user entity and add the user Id
                user.PasswordSalt = hashAndSalt.Salt;
                user.PasswordHash = hashAndSalt.Hash;
                user.Id = Guid.NewGuid();

                await _applicationContext.AddAsync(user);
                await _applicationContext.SaveChangesAsync();

                return user.Id;
            }
            catch (Exception ex)
            {
                // Log the exception and handle it as needed
                // For example, you might want to throw a custom exception or return a result indicating failure
                throw new Exception("Failed to add user", ex);
            }
        }






        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var transaction = await _applicationContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = await _applicationContext.User.FirstOrDefaultAsync(i => i.Id == id);

                    if (user == null)
                    {
                        throw new ArgumentNullException(nameof(user));
                    }
                    _applicationContext.Remove(user);
                    await _applicationContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
                
            
        }

        public async Task<bool> UpdateAsync(User userToUpdate)
        {
            try
            {
                if(userToUpdate == null)
                {
                    return false;
                }

                _applicationContext.User.Update(userToUpdate);
                await _applicationContext.SaveChangesAsync();

             
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }


        //public async Task<bool> UpdatePasswordAsync(Guid id, string password, string salt)
        //{
        //    // Start a transaction
        //    using (var transaction = await _applicationContext.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            var user = await _applicationContext.User.FindAsync(id);
        //            if (user != null)
        //            {
        //                user.Password = password;
        //                user.Salt = salt;

        //                _applicationContext.Update(user);
        //                await _applicationContext.SaveChangesAsync();

        //                // Placeholder for future logging logic (for audit logs)
        //                // LogPasswordChange(user);

        //                await transaction.CommitAsync();
        //                return true;
        //            }
        //            return false;
        //        }
        //        catch (Exception)
        //        {
        //            // If an error occurs, roll back the transaction
        //            await transaction.RollbackAsync();
        //            return false;
        //        }
        //    }
        //}


        //Helper Methods
        public class HashResult
        {
            public string Hash { get; set; }
            public byte[] Salt { get; set; }
        }

        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        async Task<HashResult> HashPasswordAsync(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(_keySize);

            var hash = await Task.Run(() => Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                _iterations,
                hashAlgorithm,
                _keySize));

            return new HashResult { Hash = Convert.ToHexString(hash), Salt = salt };
        }
    }
}