using CardTransactionApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardTransactionApi.Services
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByIdAsync(Guid userId);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
