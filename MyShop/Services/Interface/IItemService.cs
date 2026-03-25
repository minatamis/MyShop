using MyShop.Models.Base;

namespace MyShop.Services.Interface
{
    public interface IItemService
    {
        Task<Dictionary<string, object>> GetItemList();
        Task<Dictionary<string, object>> GetItemById(int id);
        Task AddItem(Item item);
        Task EditItem(Item item);
        Task DeleteItem(int id);
    }
}
