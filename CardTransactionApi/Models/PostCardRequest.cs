using System.ComponentModel.DataAnnotations;

namespace CardTransactionApi.Models
{
    public class PostCardRequest
    {
        [Required]
        public string CardNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
    }
}
