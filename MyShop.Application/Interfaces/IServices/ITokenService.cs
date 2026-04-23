using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Interfaces.IServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
