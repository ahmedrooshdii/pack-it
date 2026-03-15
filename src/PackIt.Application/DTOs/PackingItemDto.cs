namespace PackIt.Application.DTOs
{
    public class PackingItemDto
    {
        public required string Name { get; set; }
        public required uint Quantity { get; set; }
        public required bool IsPacked { get; set; }
    }
}
