using CardTransactionApi.Models;

namespace CardTransactionApi.Services
{
    public interface ICardService
    {
        Task<Card> GetCardByNumberAsync(string cardNumber);
        Task<Card> AddCardAsync(Card card);
        Task<bool> UpdateCardAsync(Card card);
        Task<bool> DeleteCardAsync(int id);
        Task CreateTransaction(CardTransaction transaction);
        // Additional method signatures as needed
    }
}
