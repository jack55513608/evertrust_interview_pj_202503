using System.Collections.Generic;
using CardTransactionApi.Repository;
using CardTransactionApi.Models;

namespace CardTransactionApi.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> GetCardByNumber(string cardNumber)
        {
            return await _cardRepository.GetCardByNumberAsync(cardNumber);
        }

        public async Task CreateTransaction(CardTransaction transaction)
        {
            // Logic to create a transaction using the card number
            await _cardRepository.AddCardAsync(transaction.Card);
        }

        // Additional methods for card-related operations
    }
}
