namespace MyShop.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal OrderAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
