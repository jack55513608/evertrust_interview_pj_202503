public enum TransactionType
{
    Buy,
    Sell
}

namespace CardTransactionApi.Models
{
    public class CardTransaction
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public Card? Card { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionTime { get; set; }
        public bool IsSettled { get; set; }
        public Guid UserId { get; set; } // Link to the user
        public TransactionType Type { get; set; } // Type of transaction
    }
}
