using MyShop.Models.Base;
using MyShop.Services.Interface;

namespace MyShop.Services
{
    public class ItemService : IItemService
    {
        private readonly IStorageService _storageService;
        public ItemService(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public async Task<List<Item>> GetItemList()
        {
            List<Item> itemList = new();
            try
            {
                itemList = _storageService.GetItemList();
            }
            catch (Exception ex)
            {
                return null;
            }
            return itemList;
        }
        public async Task<Item> GetItemById(int id)
        {
            Item item;
            try
            {
                item = _storageService.GetItem(id);
            }
            catch (Exception ex)
            {
                return null;
            }
            return item;
        }
        public Task AddItem(Item item)
        {
            try
            {
                if (item != null)
                    _storageService.AddItem(item);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
        public Task EditItem(Item item)
        {
            try
            {
                if (item != null)
                    _storageService.EditItem(item);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
        public Task DeleteItem(int id)
        {

            try
            {
                if (id != null)
                    _storageService.DeleteItem(id);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
    }
}
