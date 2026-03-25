using MyShop.Models.Base;
using MyShop.Services.Interface;

namespace MyShop.Services.Controllers
{
    public class StorageService : IStorageService
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Order> _orders = new();
        private static readonly List<Item> _items = new();
        public List<Product> ProductStorage()
        {
            return _products;
        }
        public List<Order> OrderStorage()
        {
            return _orders;
        }
        public List<Item> ItemStorage()
        {
            return _items;
        }
    }
}
