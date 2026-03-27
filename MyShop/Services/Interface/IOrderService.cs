using MyShop.Models.Base;

namespace MyShop.Services.Interface
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
