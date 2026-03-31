using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Entities;
using MyShop.Application.Interfaces.IServices;

namespace MyShop.Controllers
{
    [ApiController]
    [Route("my-shop/item")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        [Route("get-item-list")]
        public async Task<ActionResult<Response<List<Item>>>> GetItemList()
        {
            var itemList = await _itemService.GetItemList();
            try
            {
                if (itemList == null)
                    return NotFound(Response<List<Item>>.Fail);
                else
                    return Ok(Response<List<Item>>.Success(itemList, "Items Found"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<List<Item>>.Fail);
            }
        }
        [HttpGet]
        [Route("get-item")]
        public async Task<ActionResult<Response<Item>>> GetItemById(int id)
        {
            var item = await _itemService.GetItemById(id);
            try
            {
                if (item == null)
                    return NotFound(Response<Item>.Fail);
                else
                    return Ok(Response<Item>.Success(item, "Item Found"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<Item>.Fail);
            }
        }
        [HttpPost]
        [Route("add-item")]
        public async Task<IActionResult> AddItem(Item item)
        {
            try
            {
                await _itemService.AddItem(item);
                return Ok(Response<object>.Success(item, "Item added successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
        [HttpPut]
        [Route("edit-item")]
        public async Task<IActionResult> EditItem(Item item)
        {
            try
            {
                await _itemService.EditItem(item);
                return Ok(Response<object>.Success(item, "Item edited successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
        [HttpDelete]
        [Route("delete-item")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                await _itemService.DeleteItem(id);
                return Ok(Response<object>.Success(id, "Item deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
    }
}