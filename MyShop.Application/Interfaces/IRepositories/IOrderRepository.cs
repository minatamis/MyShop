using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Interfaces.IRepositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrderList();
        Task<Order> GetOrder(int id);
        Task AddOrder(Order order);
        Task EditOrder(Order order);
        Task DeleteOrder(Order order);
    }
}
