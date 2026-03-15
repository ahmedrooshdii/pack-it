namespace PackIt.Application.DTOs
{
    public class PackingListDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required LocalizationDto Localization { get; set; }
        public required IEnumerable<PackingItemDto> Items { get; set; }
    }
}
