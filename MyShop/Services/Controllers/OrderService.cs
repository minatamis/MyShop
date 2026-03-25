using MyShop.Models.Base;
using MyShop.Services.Interface;
using System.Linq;

namespace MyShop.Services.Controllers
{
    public class OrderService : IOrderService
    {
        private readonly IStorageService _storageService;
        public OrderService(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public Task<Dictionary<string, object>> GetOrderList()
        {
            var orderList = new List<Order>();
            var result = new Dictionary<string, object>();
            try
            {
                orderList = _storageService.OrderStorage();
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "success",
                    ["OrderList"] = orderList
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            
            return Task.FromResult(result);
        }
        public Task<Dictionary<string, object>> GetOrderById(int id)
        {
            var order = new Order();
            var result = new Dictionary<string, object>();
            try
            {
                order = _storageService.OrderStorage().FirstOrDefault(o => o.OrderId == id);
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "success",
                    ["Order"] = order
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            
            return Task.FromResult(result);
        }
        public async Task AddOrder(Order order)
        {
            var result = new Dictionary<string, object>();
            try
            {
                _storageService.OrderStorage().Add(order);
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "order added"
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            
            await Task.FromResult(result);
        }
        public async Task EditOrder(Order order)
        {
            var result = new Dictionary<string, object>();
            try
            {
                var editOrder = _storageService.OrderStorage().FirstOrDefault(o => o.OrderId == order.OrderId);
                if (editOrder != null)
                {
                    editOrder.OrderId = order.OrderId;
                    editOrder.OrderAmount = order.OrderAmount;
                    editOrder.OrderStatus = order.OrderStatus;

                }
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "order edited"
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            
            await Task.FromResult(result);
        }
        public async Task DeleteOrder(int id)
        {
            var result = new Dictionary<string, object>();
            try
            {
                Order order = _storageService.OrderStorage().FirstOrDefault(o => o.OrderId == id);
                if (order != null)
                {
                    _storageService.OrderStorage().Remove(order);
                }
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "order deleted",
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            
            await Task.FromResult(result);
        }
    }
}
