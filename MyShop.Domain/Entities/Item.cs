namespace MyShop.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ProductId { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemStatus { get; set; }
    }
}
