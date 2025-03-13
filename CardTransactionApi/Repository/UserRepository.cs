using CardTransactionApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CardTransactionApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<User> AddUserAsync(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                INSERT INTO Users (UserName, Email) 
                OUTPUT INSERTED.UserId
                VALUES (@UserName, @Email)";
            user.UserId = await connection.ExecuteScalarAsync<Guid>(sql, user);
            return user;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Users WHERE UserId = @UserId";
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { UserId = userId });
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                UPDATE Users 
                SET UserName = @UserName, Email = @Email 
                WHERE UserId = @UserId";
            var affected = await connection.ExecuteAsync(sql, user);
            return affected > 0;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Users WHERE UserId = @UserId";
            var affected = await connection.ExecuteAsync(sql, new { UserId = userId });
            return affected > 0;
        }
    }
}
