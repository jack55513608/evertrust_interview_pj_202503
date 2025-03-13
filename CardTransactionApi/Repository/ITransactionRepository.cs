using CardTransactionApi.Models;

namespace CardTransactionApi.Repository
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<CardTransaction>> GetTransactionsAsync();
        Task<CardTransaction?> GetTransactionByIdAsync(int id);
        Task<int> AddTransactionAsync(CardTransaction transaction);
        Task<bool> UpdateTransactionAsync(CardTransaction transaction);
        Task<bool> DeleteTransactionAsync(int id);
        Task<IEnumerable<CardTransaction>> GetTransactionsByUserIdAsync(Guid userId); // New method to get transactions by user
    }
}
