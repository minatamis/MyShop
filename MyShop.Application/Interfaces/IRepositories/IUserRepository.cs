using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsername(string username);
        Task AddUser(User user);
    }
}
