using Microsoft.EntityFrameworkCore;
using MyShop.Application.Interfaces.IRepositories;
using MyShop.Domain.Entities;
using MyShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Product> _products;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
            _products = _context.Set<Product>();
        }
        public async Task<List<Product>> GetProductList() => await _products.ToListAsync();
        public async Task<Product> GetProduct(int id) => await _products.FindAsync(id);
        public async Task AddProduct(Product product)
        {
            await _products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task EditProduct(Product product)
        {
            _products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
