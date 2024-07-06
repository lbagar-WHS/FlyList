namespace FlyList.Models
{
    public class Product : SqlEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int StandardAmount { get; set; } = 1;
        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = new();
    }
}
