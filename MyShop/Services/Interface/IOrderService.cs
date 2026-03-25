using MyShop.Models.Base;

namespace MyShop.Services.Interface
{
    public interface IOrderService
    {
        Task<Dictionary<string, object>> GetOrderList();
        Task<Dictionary<string, object>> GetOrderById(int id);
        Task AddOrder(Order order);
        Task EditOrder(Order order);
        Task DeleteOrder(int id);
    }
}
