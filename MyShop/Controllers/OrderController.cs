using Microsoft.AspNetCore.Mvc;
using MyShop.Models.Base;
using MyShop.Services.Controllers;
using MyShop.Services.Interface;

namespace MyShop.Controllers
{
    [ApiController]
    [Route("my-shop/order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("get-order-list")]
        public async Task<IActionResult> GetOrderList()
        {
            var orderList = await _orderService.GetOrderList();
            return Ok(orderList);
        }
        [HttpGet]
        [Route("get-order")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            return Ok(order);
        }
        [HttpPost]
        [Route("add-order")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            await _orderService.AddOrder(order);
            return Ok();
        }
        [HttpPut]
        [Route("edit-order")]
        public async Task<IActionResult> EditOrder(Order order)
        {
            await _orderService.EditOrder(order);
            return Ok();
        }
        [HttpDelete]
        [Route("delete-order")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
