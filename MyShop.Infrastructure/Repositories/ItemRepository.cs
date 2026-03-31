using Microsoft.EntityFrameworkCore;
using MyShop.Application.Interfaces.IRepositories;
using MyShop.Domain.Entities;
using MyShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Item> _items;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
            _items = _context.Set<Item>();
        }
        public async Task<List<Item>> GetItemList() => await _items.ToListAsync();
        public async Task<Item> GetItem(int id) => await _items.FindAsync(id);
        public async Task AddItem(Item item)
        {
            await _items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task EditItem(Item item)
        {
            _items.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Item item)
        {
            _items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
