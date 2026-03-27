using MyShop.Models.Base;
using MyShop.Services.Interface;

namespace MyShop.Services
{
    public class StorageService : IStorageService
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Order> _orders = new();
        private static readonly List<Item> _items = new();
        //Product
        public List<Product> GetProductList()
        {
            return _products;
        }
        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(o => o.ProductId == id);
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public void EditProduct(Product product)
        {
            var editProd = _products.FirstOrDefault(o => o.ProductId == product.ProductId);

            editProd.ProductId = product.ProductId;
            editProd.ProductName = product.ProductName;
            editProd.ProductPrice = product.ProductPrice;

        }
        public void DeleteProduct(int id)
        {
            var toBeDeleted = _products.FirstOrDefault(o => o.ProductId == id);
            _products.Remove(toBeDeleted);

        }

        //Order
        public List<Order> GetOrderList()
        {
            return _orders;
        }
        public Order GetOrder(int id)
        {
            return _orders.FirstOrDefault(o => o.OrderId == id);
        }
        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }
        public void EditOrder(Order order)
        {
            var editOrder = _orders.FirstOrDefault(o => o.OrderId == order.OrderId);

            editOrder.OrderId = order.OrderId;
            editOrder.OrderAmount = order.OrderAmount;
            editOrder.OrderStatus = order.OrderStatus;

        }
        public void DeleteOrder(int id)
        {
            var toBeDeleted = _orders.FirstOrDefault(o => o.OrderId == id);
            _orders.Remove(toBeDeleted);
        }

        //Item
        public List<Item> GetItemList()
        {
            return _items;
        }
        public Item GetItem(int id)
        {
            return _items.FirstOrDefault(o => o.ItemId == id);
        }
        public void AddItem(Item item)
        {
            _items.Add(item);
        }
        public void EditItem(Item item)
        {
            var edititem = _items.FirstOrDefault(o => o.ItemId == item.ItemId);

            edititem.ItemId = item.ItemId;
            edititem.ItemName = item.ItemName;
            edititem.ProductId = item.ProductId;
            edititem.ItemQuantity = item.ItemQuantity;
            edititem.ItemStatus = item.ItemStatus;

        }
        public void DeleteItem(int id)
        {
            var toBeDeleted = _items.FirstOrDefault(o => o.ItemId == id);
            _items.Remove(toBeDeleted);
        }
    }
}
