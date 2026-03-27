using MyShop.Models.Base;
using MyShop.Services.Interface;
using System.Linq;

namespace MyShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IStorageService _storageService;
        public OrderService(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public async Task<List<Order>> GetOrderList()
        {
            List<Order> orderList = new();
            try
            {
                orderList = _storageService.GetOrderList();
            }
            catch (Exception ex)
            {
                return null;
            }
            return orderList;
        }
        public async Task<Order> GetOrderById(int id)
        {
            Order order;
            try
            {
                order = _storageService.GetOrder(id);
            }
            catch (Exception ex)
            {
                return null;
            }
            return order;
        }
        public Task AddOrder(Order order)
        {
            try
            {
                if (order != null)
                    _storageService.AddOrder(order);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
        public Task EditOrder(Order order)
        {
            try
            {
                if (order != null)
                    _storageService.EditOrder(order);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
        public Task DeleteOrder(int id)
        {

            try
            {
                if (id != null)
                    _storageService.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
    }
}
