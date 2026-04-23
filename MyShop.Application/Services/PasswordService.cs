using Microsoft.AspNetCore.Identity;
using MyShop.Application.Interfaces.IServices;
using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<User> _hasher = new();
        public string Hash(User user, string password)
        {
            return _hasher.HashPassword(user, password);
        }
        public bool VerifyPassword(User user, string password)
        {
            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
