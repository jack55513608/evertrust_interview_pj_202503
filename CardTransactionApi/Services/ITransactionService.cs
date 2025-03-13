using CardTransactionApi.Models;

namespace CardTransactionApi.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<CardTransaction>> GetTransactionsByUserIdAsync(Guid userId);
        Task<int> AddTransactionAsync(CardTransaction transaction);
        Task<IEnumerable<CardTransaction>> GetTransactionsAsync();
        Task<CardTransaction?> GetTransactionByIdAsync(int id);
        Task<bool> UpdateTransactionAsync(CardTransaction transaction);
        Task<bool> DeleteTransactionAsync(int id);
    }
}
