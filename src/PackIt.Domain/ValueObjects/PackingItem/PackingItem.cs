namespace PackIt.Domain.ValueObjects.PackingItem
{
    public record PackingItem
    {
        public PackingItemName Name { get; }
        public ushort Quantity { get; }
        public bool IsPacked { get; init; }

        public PackingItem(PackingItemName name, ushort quantity, bool isPacked = false)
        {
            Name = name;
            Quantity = quantity;
            IsPacked = isPacked;
        }
    }
}
