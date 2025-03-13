namespace CardTransactionApi.Models
{
    public class TransactionRequest
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        // Additional properties as needed
    }
}
