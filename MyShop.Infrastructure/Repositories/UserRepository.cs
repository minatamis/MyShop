using Microsoft.EntityFrameworkCore;
using MyShop.Application.Interfaces.IRepositories;
using MyShop.Domain.Entities;
using MyShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<User> _user;
        public UserRepository(AppDbContext context)
        {
            _context = context;
            _user = _context.Set<User>();
        }

        public async Task<User?> GetByUsername(string username)
        {
            return _user.FirstOrDefault(u => u.Username == username);
        }
        public async Task AddUser(User user)
        {
            await _user.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
