using CardTransactionApi.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CardTransactionApi.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<CardTransaction>> GetTransactionsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                SELECT t.*, c.Id, c.CardNumber, c.Name, c.Specification 
                FROM CardTransactions t
                INNER JOIN Cards c ON t.CardId = c.Id";
            var transactions = await connection.QueryAsync<CardTransaction, Card, CardTransaction>(
                sql,
                (transaction, card) =>
                {
                    transaction.Card = card;
                    return transaction;
                });
            return transactions;
        }

        public async Task<CardTransaction?> GetTransactionByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                SELECT t.*, c.Id, c.CardNumber, c.Name, c.Specification 
                FROM CardTransactions t
                INNER JOIN Cards c ON t.CardId = c.Id
                WHERE t.Id = @Id";
            var result = await connection.QueryAsync<CardTransaction, Card, CardTransaction>(
                sql,
                (transaction, card) =>
                {
                    transaction.Card = card;
                    return transaction;
                },
                new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<int> AddTransactionAsync(CardTransaction transaction)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                INSERT INTO CardTransactions (CardId, Price, TransactionTime, IsSettled) 
                OUTPUT INSERTED.Id
                VALUES (@CardId, @Price, @TransactionTime, @IsSettled)";
            var id = await connection.ExecuteScalarAsync<int>(sql, transaction);
            return id;
        }

        public async Task<bool> UpdateTransactionAsync(CardTransaction transaction)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                UPDATE CardTransactions 
                SET CardId = @CardId, Price = @Price, TransactionTime = @TransactionTime, IsSettled = @IsSettled 
                WHERE Id = @Id";
            var affected = await connection.ExecuteAsync(sql, transaction);
            return affected > 0;
        }

        public async Task<bool> DeleteTransactionAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM CardTransactions WHERE Id = @Id";
            var affected = await connection.ExecuteAsync(sql, new { Id = id });
            return affected > 0;
        }

        public async Task<IEnumerable<CardTransaction>> GetTransactionsByUserIdAsync(Guid userId)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"
                SELECT t.*, c.Id, c.CardNumber, c.Name, c.Specification 
                FROM CardTransactions t
                INNER JOIN Cards c ON t.CardId = c.Id
                WHERE t.UserId = @UserId";
            var transactions = await connection.QueryAsync<CardTransaction, Card, CardTransaction>(
                sql,
                (transaction, card) =>
                {
                    transaction.Card = card;
                    return transaction;
                },
                new { UserId = userId });
            return transactions;
        }
    }
}
