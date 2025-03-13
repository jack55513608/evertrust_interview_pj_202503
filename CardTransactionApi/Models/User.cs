using System;

namespace CardTransactionApi.Models
{
    public class User
    {
        public Guid UserId { get; set; } // Unique identifier for the user
        public string UserName { get; set; } // Name of the user
        public string Email { get; set; } // Email address of the user
    }
}
