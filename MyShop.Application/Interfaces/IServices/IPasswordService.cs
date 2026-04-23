using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Interfaces.IServices
{
    public interface IPasswordService
    {
        string Hash(User user, string password);
        bool VerifyPassword(User user, string password);
    }
}
