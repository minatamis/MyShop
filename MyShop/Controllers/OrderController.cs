using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Entities;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        [HttpGet("get-order-list")]
        public async Task<ActionResult<Response<List<Order>>>> GetOrderList()
        {
            var orderList = await _orderService.GetOrderList();
            try
            {
                if (orderList == null)
                {
                    _logger.LogWarning("Orders list is null");
                    return NotFound(Response<List<Order>>.Fail("Order not found"));
                }
                else
                {
                    _logger.LogInformation($"{orderList.Count} Orders Found");
                    return Ok(Response<List<Order>>.Success(orderList, "Orders Found"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order list");
                return BadRequest(Response<List<Order>>.Fail(ex.ToString()));
            }
        }
        [HttpGet("get-order")]
        public async Task<ActionResult<Response<Order>>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            try
            {
                if (order == null)
                {
                    _logger.LogWarning($"Order {id} is null");
                    return NotFound(Response<Order>.Fail("Order not found"));
                }
                else
                {
                    _logger.LogInformation($"Order {id} is found");
                    return Ok(Response<Order>.Success(order, "Order Found"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching order");
                return BadRequest(Response<Order>.Fail(ex.ToString()));
            }
        }
        [HttpPost("add-order")]
        public async Task<ActionResult<Response<object>>> AddOrder(Order order)
        {
            try
            {
                await _orderService.AddOrder(order);
                _logger.LogInformation($"Order {order.OrderId} successfully created");
                return Ok(Response<object>.Success(order, "Order added successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
        [HttpPut("edit-order")]
        public async Task<ActionResult<Response<object>>> EditOrder(Order order)
        {
            try
            {
                await _orderService.EditOrder(order);
                _logger.LogInformation($"Order {order.OrderId} successfully updated");
                return Ok(Response<object>.Success(order, "Order edited successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
        [HttpDelete("delete-order")]
        public async Task<ActionResult<Response<object>>> DeleteOrder(int id)
        {
            try
            {
                await _orderService.DeleteOrder(id);
                _logger.LogInformation($"Order {id} successfully deleted");
                return Ok(Response<object>.Success(id, "Order deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
    }
}
