using MyShop.Models.Base;

namespace MyShop.Services.Interface
{
    public interface IStorageService
    {
        //Product
        List<Product> GetProductList();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(int id);
        
        //Order
        List<Order> GetOrderList();
        Order GetOrder(int id);
        void AddOrder(Order order);
        void EditOrder(Order order);
        void DeleteOrder(int id);

        //Item
        List<Item> GetItemList();
        Item GetItem(int id);
        void AddItem(Item item);
        void EditItem(Item item);
        void DeleteItem(int id);
    }
}
