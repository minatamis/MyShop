using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Domain.Entities
{
    public class RefreshToken
    {
        public int TokenId { get; set; }
        public string Token {  get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
