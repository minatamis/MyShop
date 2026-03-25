using Microsoft.AspNetCore.Mvc;
using MyShop.Models.Base;
using MyShop.Services.Interface;

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
        public async Task<IActionResult> GetItemList()
        {
            var itemList = await _itemService.GetItemList();
            return Ok(itemList);
        }
        [HttpGet]
        [Route("get-item")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var item = await _itemService.GetItemById(id);
            return Ok(item);
        }
        [HttpPost]
        [Route("add-item")]
        public async Task<IActionResult> AddItem(Item item)
        {
            await _itemService.AddItem(item);
            return Ok();
        }
        [HttpPut]
        [Route("edit-item")]
        public async Task<IActionResult> EditItem(Item item)
        {
            await _itemService.EditItem(item);
            return Ok();
        }
        [HttpDelete]
        [Route("delete-item")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemService.DeleteItem(id);
            return Ok();
        }
    }
}