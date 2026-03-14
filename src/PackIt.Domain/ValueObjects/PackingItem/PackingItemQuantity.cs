using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects.PackingItem
{
    public record PackingItemQuantity
    {
        public ushort Value { get; }

        public PackingItemQuantity(ushort quantity)
        {
            if (quantity <= 0)
            {
                throw new EmptyPackingListItemNameException();
            }

            Value = quantity;
        }

        public static implicit operator ushort(PackingItemQuantity quantity)
            => quantity.Value;

        public static implicit operator PackingItemQuantity(ushort value)
            => new(value);
    }
}
