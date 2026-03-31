using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Application.Interfaces.IRepositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItemList();
        Task<Item> GetItem(int id);
        Task AddItem(Item item);
        Task EditItem(Item item);
        Task DeleteItem(Item item);
    }
}
