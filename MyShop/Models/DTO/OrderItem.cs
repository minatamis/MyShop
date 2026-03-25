using MyShop.Models.Base;

namespace MyShop.Models.DTO
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public List<Order> Orders { get; set; }
        public List<Item> Items { get; set; }
        public double OrderItemTotalAmount { get; set; }
    }
}
