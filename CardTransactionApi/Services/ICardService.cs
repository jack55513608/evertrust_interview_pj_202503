using CardTransactionApi.Models;

namespace CardTransactionApi.Services
{
    public interface ICardService
    {
        Task<Card> GetCardByNumber(string cardNumber);
        Task CreateTransaction(CardTransaction transaction);
        // Additional method signatures as needed
    }
}
