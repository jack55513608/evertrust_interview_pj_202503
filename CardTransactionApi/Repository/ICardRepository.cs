using CardTransactionApi.Models;

namespace CardTransactionApi.Repository
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetCardsAsync();
        Task<Card?> GetCardByIdAsync(int id);
        Task<Card?> GetCardByNumberAsync(string cardNumber);
        Task<int> AddCardAsync(Card card);
        Task<bool> UpdateCardAsync(Card card);
        Task<bool> DeleteCardAsync(int id);
    }
}
