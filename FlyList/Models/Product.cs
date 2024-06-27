namespace FlyList.Models
{
    public class Product : SqlEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int StandardAmount { get; set; } = 1;
        public Category? Category { get; set; }
    }
}
