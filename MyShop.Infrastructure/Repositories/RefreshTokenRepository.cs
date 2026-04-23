using Microsoft.EntityFrameworkCore;
using MyShop.Application.Interfaces.IRepositories;
using MyShop.Domain.Entities;
using MyShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<RefreshToken> _refreshTokens;
        public RefreshTokenRepository(AppDbContext context)
        {
            _context = context;
            _refreshTokens = _context.Set<RefreshToken>();
        }
        public async Task AddToken(RefreshToken token)
        {
            await _refreshTokens.AddAsync(token);
            await SaveChanges();
        }
        public async Task<RefreshToken?> GetRefreshToken(string token)
        {
            return await _refreshTokens
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Token == token);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
