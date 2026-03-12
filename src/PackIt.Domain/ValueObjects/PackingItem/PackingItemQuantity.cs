using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects.PackingItem
{
    public record PackingItemQuantity
    {
        public string Value { get; }

        public PackingItemQuantity(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyPackingListItemNameException();
            }

            Value = name;
        }

        public static implicit operator string(PackingItemQuantity quantity)
            => quantity.Value;

        public static implicit operator PackingItemQuantity(string value)
            => new(value);
    }
}
