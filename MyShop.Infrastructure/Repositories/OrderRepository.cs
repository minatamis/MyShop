using Microsoft.EntityFrameworkCore;
using MyShop.Application.Interfaces.IRepositories;
using MyShop.Domain.Entities;
using MyShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<Order> _orders;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
            _orders = _context.Set<Order>();
        }
        public async Task<List<Order>> GetOrderList() => await _orders.ToListAsync();
        public async Task<Order> GetOrder(int id) => await _orders.FindAsync(id);
        public async Task AddOrder(Order order)
        {
            await _orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task EditOrder(Order order)
        {
            _orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Order order)
        {
            _orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
