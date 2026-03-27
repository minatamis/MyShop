using Microsoft.AspNetCore.Mvc;
using MyShop.Models.Base;
using MyShop.Services;
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
        public async Task<ActionResult<Response<List<Order>>>> GetOrderList()
        {
            var orderList = await _orderService.GetOrderList();
            try
            {
                if (orderList == null)
                    return NotFound(Response<List<Order>>.Fail);
                else
                    return Ok(Response<List<Order>>.Success(orderList, "Orders Found"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<List<Order>>.Fail);
            }
        }
        [HttpGet]
        [Route("get-order")]
        public async Task<ActionResult<Response<Order>>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            try
            {
                if (order == null)
                    return NotFound(Response<Order>.Fail);
                else
                    return Ok(Response<Order>.Success(order, "Order Found"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<Order>.Fail);
            }
        }
        [HttpPost]
        [Route("add-order")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            try
            {
                await _orderService.AddOrder(order);
                return Ok(Response<object>.Success);
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
        [HttpPut]
        [Route("edit-order")]
        public async Task<IActionResult> EditOrder(Order order)
        {
            try
            {
                await _orderService.EditOrder(order);
                return Ok(Response<object>.Success);
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
        [HttpDelete]
        [Route("delete-order")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderService.DeleteOrder(id);
                return Ok(Response<object>.Success);
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
    }
}
