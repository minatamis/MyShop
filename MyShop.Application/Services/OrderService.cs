using Microsoft.Extensions.Logging;
using MyShop.Application.Interfaces.IRepositories;
using MyShop.Application.Interfaces.IServices;
using MyShop.Domain.Entities;

namespace MyShop.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<List<Order>> GetOrderList()
        {
            try
            {
                _logger.LogInformation("Orders fetching from service");
                return await _orderRepository.GetOrderList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order list");
                return null;
            }
        }
        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                _logger.LogInformation($"Order {id} fetching from service");
                return await _orderRepository.GetOrder(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order");
                return null;
            }
        }
        public async Task AddOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    _logger.LogInformation($"Creating order {order.OrderId}");
                    await _orderRepository.AddOrder(order);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order order");
                throw;
            }
        }
        public async Task EditOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    _logger.LogInformation($"Updating order {order.OrderId}");
                    await _orderRepository.EditOrder(order);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order");
                throw;
            }
        }
        public async Task DeleteOrder(int id)
        {

            try
            {
                var order = await _orderRepository.GetOrder(id);
                if (order != null)
                {
                    _logger.LogInformation($"Deleting order {order.OrderId}");
                    await _orderRepository.DeleteOrder(order);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting order");
                throw;
            }
        }
    }
}
