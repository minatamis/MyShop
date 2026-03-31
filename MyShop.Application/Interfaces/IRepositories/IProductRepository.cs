using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductList();
        Task<Product> GetProduct(int id);
        Task AddProduct(Product product);
        Task EditProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
