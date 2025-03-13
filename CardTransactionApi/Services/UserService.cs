using CardTransactionApi.Models;
using CardTransactionApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardTransactionApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository; // Assuming a user repository exists

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await _userRepository.AddUserAsync(user);
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}
