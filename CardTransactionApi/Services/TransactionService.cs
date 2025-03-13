using CardTransactionApi.Models;
using CardTransactionApi.Repository;

namespace CardTransactionApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<CardTransaction>> GetTransactionsByUserIdAsync(Guid userId)
        {
            return await _transactionRepository.GetTransactionsByUserIdAsync(userId);
        }

        public async Task<int> AddTransactionAsync(CardTransaction transaction)
        {
            return await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task<IEnumerable<CardTransaction>> GetTransactionsAsync()
        {
            return await _transactionRepository.GetTransactionsAsync();
        }

        public async Task<CardTransaction?> GetTransactionByIdAsync(int id)
        {
            return await _transactionRepository.GetTransactionByIdAsync(id);
        }

        public async Task<bool> UpdateTransactionAsync(CardTransaction transaction)
        {
            return await _transactionRepository.UpdateTransactionAsync(transaction);
        }

        public async Task<bool> DeleteTransactionAsync(int id)
        {
            return await _transactionRepository.DeleteTransactionAsync(id);
        }
    }
}
