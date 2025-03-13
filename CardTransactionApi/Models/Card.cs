namespace CardTransactionApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
    }
}
