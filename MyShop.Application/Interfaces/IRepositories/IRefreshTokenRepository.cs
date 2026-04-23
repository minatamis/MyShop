using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Interfaces.IRepositories
{
    public interface IRefreshTokenRepository
    {
        Task AddToken(RefreshToken token);
        Task<RefreshToken?> GetRefreshToken(string token);
        Task SaveChanges();
    }
}
