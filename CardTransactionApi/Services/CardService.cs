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

        public async Task<Card> GetCardByNumberAsync(string cardNumber)
        {
            return await _cardRepository.GetCardByNumberAsync(cardNumber);
        }

        public async Task<Card> AddCardAsync(Card card)
        {
            var id = await _cardRepository.AddCardAsync(card);
            card.Id = id; // Assuming the repository sets the ID
            return card;
        }

        public async Task<bool> UpdateCardAsync(Card card)
        {
            return await _cardRepository.UpdateCardAsync(card);
        }

        public async Task<bool> DeleteCardAsync(int id)
        {
            return await _cardRepository.DeleteCardAsync(id);
        }

        public async Task CreateTransaction(CardTransaction transaction)
        {
            // Logic to create a transaction using the card number
            await _cardRepository.AddCardAsync(transaction.Card);
        }
    }
}
