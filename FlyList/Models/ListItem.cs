namespace FlyList.Models
{
    public class ListItem : SqlEntity
    {
        public bool IsBought { get; set; }
        public int Amount { get; set; }
        public Guid ProductId { get; set; }

        public Product Product { get; set; } = new();
    }
}
