using Microsoft.Extensions.Logging;
using MyShop.Application.Interfaces.IRepositories;
using MyShop.Application.Interfaces.IServices;
using MyShop.Domain.Entities;

namespace MyShop.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<ItemService> _logger;
        public ItemService(IItemRepository itemRepository, ILogger<ItemService> logger)
        {
            _itemRepository = itemRepository;
            _logger = logger;
        }

        public async Task<List<Item>> GetItemList()
        {
            try
            {
                _logger.LogInformation("Items fetching from service");
                return await _itemRepository.GetItemList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching item list");
                return null;
            }
        }
        public async Task<Item> GetItemById(int id)
        {
            try
            {
                _logger.LogInformation($"Item {id} fetching from service");
                return await _itemRepository.GetItem(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching item");
                return null;
            }
        }
        public async Task AddItem(Item item)
        {
            try
            {
                if (item != null)
                {
                    _logger.LogInformation($"Creating item {item.ItemId}");
                    await _itemRepository.AddItem(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating item item");
                throw;
            }
        }
        public async Task EditItem(Item item)
        {
            try
            {
                if (item != null)
                {
                    _logger.LogInformation($"Updating item {item.ItemId}");
                    await _itemRepository.EditItem(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating item");
                throw;
            }
        }
        public async Task DeleteItem(int id)
        {

            try
            {
                var item = await _itemRepository.GetItem(id);
                if (item != null)
                {
                    _logger.LogInformation($"Deleting item {item.ItemId}");
                    await _itemRepository.DeleteItem(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting item");
                throw;
            }
        }
    }
}
