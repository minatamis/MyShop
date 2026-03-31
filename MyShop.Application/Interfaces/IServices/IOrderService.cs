using MyShop.Domain.Entities;

namespace MyShop.Application.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrderList();
        Task<Order> GetOrderById(int id);
        Task AddOrder(Order order);
        Task EditOrder(Order order);
        Task DeleteOrder(int id);
    }
}
