using MyShop.Application.Interfaces.IRepositories;
using MyShop.Application.Interfaces.IServices;
using MyShop.Domain.Entities;

namespace MyShop.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> GetOrderList()
        {
            try
            {
                return await _orderRepository.GetOrderList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                return await _orderRepository.GetOrder(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task AddOrder(Order order)
        {
            try
            {
                if (order != null)
                    await _orderRepository.AddOrder(order);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task EditOrder(Order order)
        {
            try
            {
                if (order != null)
                    await _orderRepository.EditOrder(order);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteOrder(int id)
        {

            try
            {
                var order = await _orderRepository.GetOrder(id);
                if (order != null)
                    await _orderRepository.DeleteOrder(order);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
