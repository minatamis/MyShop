using MyShop.Models.Base;

namespace MyShop.Services.Interface
{
    public interface IStorageService
    {
        List<Product> ProductStorage();
        List<Order> OrderStorage();
        List<Item> ItemStorage();
    }
}
