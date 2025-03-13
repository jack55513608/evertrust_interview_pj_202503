using CardTransactionApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CardTransactionApi.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly string _connectionString;
        public CardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<IEnumerable<Card>> GetCardsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Cards";
            return await connection.QueryAsync<Card>(sql);
        }
        public async Task<Card?> GetCardByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Cards WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Card>(sql, new { Id = id });
        }
        public async Task<int> AddCardAsync(Card card)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                INSERT INTO Cards (CardNumber, Name, Specification) 
                OUTPUT INSERTED.Id
                VALUES (@CardNumber, @Name, @Specification)";
            var id = await connection.ExecuteScalarAsync<int>(sql, card);
            return id;
        }
        public async Task<bool> UpdateCardAsync(Card card)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                UPDATE Cards 
                SET CardNumber = @CardNumber, Name = @Name, Specification = @Specification 
                WHERE Id = @Id";
            var affected = await connection.ExecuteAsync(sql, card);
            return affected > 0;
        }
        public async Task<bool> DeleteCardAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Cards WHERE Id = @Id";
            var affected = await connection.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }
    }
}
