using MyShop.Application.Interfaces.IRepositories;
using MyShop.Application.Interfaces.IServices;
using MyShop.Domain.Entities;

namespace MyShop.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<List<Item>> GetItemList()
        {
            try
            {
                return await _itemRepository.GetItemList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Item> GetItemById(int id)
        {
            try
            {
                return await _itemRepository.GetItem(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task AddItem(Item item)
        {
            try
            {
                if (item != null)
                    await _itemRepository.AddItem(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task EditItem(Item item)
        {
            try
            {
                if (item != null)
                    await _itemRepository.EditItem(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteItem(int id)
        {

            try
            {
                var item = await _itemRepository.GetItem(id);
                if (item != null)
                    await _itemRepository.DeleteItem(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
