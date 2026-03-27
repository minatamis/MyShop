using MyShop.Models.Base;

namespace MyShop.Services.Interface
{
    public interface IItemService
    {
        Task<List<Item>> GetItemList();
        Task<Item> GetItemById(int id);
        Task AddItem(Item item);
        Task EditItem(Item item);
        Task DeleteItem(int id);
    }
}
