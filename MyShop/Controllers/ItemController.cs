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
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;
        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }
        [HttpGet("get-item-list")]
        public async Task<ActionResult<Response<List<Item>>>> GetItemList()
        {
            var itemList = await _itemService.GetItemList();
            try
            {
                if (itemList == null)
                {
                    _logger.LogWarning("Items list is null");
                    return NotFound(Response<List<Item>>.Fail("Item not found"));
                }
                else
                {
                    _logger.LogInformation($"{itemList.Count} Items Found");
                    return Ok(Response<List<Item>>.Success(itemList, "Items Found"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching item list");
                return BadRequest(Response<List<Item>>.Fail(ex.ToString()));
            }
        }
        [HttpGet("get-item")]
        public async Task<ActionResult<Response<Item>>> GetItemById(int id)
        {
            var item = await _itemService.GetItemById(id);
            try
            {
                if (item == null)
                {
                    _logger.LogWarning($"Item {id} is null");
                    return NotFound(Response<Item>.Fail("Item not found"));
                }
                else
                {
                    _logger.LogInformation($"Item {id} is found");
                    return Ok(Response<Item>.Success(item, "Item Found"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching item");
                return BadRequest(Response<Item>.Fail(ex.ToString()));
            }
        }
        [HttpPost("add-item")]
        public async Task<ActionResult<Response<object>>> AddItem(Item item)
        {
            try
            {
                await _itemService.AddItem(item);
                _logger.LogInformation($"Item {item.ItemId} successfully created");
                return Ok(Response<object>.Success(item, "Item added successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating item");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
        [HttpPut("edit-item")]
        public async Task<ActionResult<Response<object>>> EditItem(Item item)
        {
            try
            {
                await _itemService.EditItem(item);
                _logger.LogInformation($"Item {item.ItemId} successfully updated");
                return Ok(Response<object>.Success(item, "Item edited successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating item");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
        [HttpDelete("delete-item")]
        public async Task<ActionResult<Response<object>>> DeleteItem(int id)
        {
            try
            {
                await _itemService.DeleteItem(id);
                _logger.LogInformation($"Item {id} successfully deleted");
                return Ok(Response<object>.Success(id, "Item deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating item");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
    }
}