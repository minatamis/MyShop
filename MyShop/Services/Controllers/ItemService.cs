using MyShop.Models.Base;
using MyShop.Services.Interface;

namespace MyShop.Services.Controllers
{
    public class ItemService : IItemService
    {
        private readonly IStorageService _storageService;
        public ItemService(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public Task<Dictionary<string, object>> GetItemList()
        {
            var itemList = new List<Item>();
            var result = new Dictionary<string, object>();
            try
            {
                itemList = _storageService.ItemStorage();
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "success",
                    ["ItemList"] = itemList
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
        public Task<Dictionary<string, object>> GetItemById(int id)
        {
            var item = new Item();
            var result  = new Dictionary<string, object>();
            try
            {
                item = _storageService.ItemStorage().FirstOrDefault(o => o.ItemId == id);
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "success",
                    ["Item"] = item
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
        public async Task AddItem(Item item)
        {
            var result = new Dictionary<string, object>();
            try
            {
                _storageService.ItemStorage().Add(item);
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "Item added"
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
        public async Task EditItem(Item item)
        {
            var result = new Dictionary<string, object>();
            try
            {
                var edititem = _storageService.ItemStorage().FirstOrDefault(o => o.ItemId == item.ItemId);
                if (edititem != null)
                {
                    edititem.ItemId = item.ItemId;
                    edititem.ItemName = item.ItemName;
                    edititem.ProductId = item.ProductId;
                    edititem.ItemQuantity = item.ItemQuantity;
                    edititem.ItemStatus = item.ItemStatus;
                }
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "Item edited"
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
        public async Task DeleteItem(int id)
        {
            var result = new Dictionary<string, object>();
            try
            {
                Item item = _storageService.ItemStorage().FirstOrDefault(o => o.ItemId == id);
                if (item != null)
                {
                    _storageService.ItemStorage().Remove(item);
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
