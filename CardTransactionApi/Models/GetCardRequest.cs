using System.ComponentModel.DataAnnotations;

namespace CardTransactionApi.Models
{
    public class GetCardRequest
    {
        [Required]
        public string CardNumber { get; set; }
    }
}
