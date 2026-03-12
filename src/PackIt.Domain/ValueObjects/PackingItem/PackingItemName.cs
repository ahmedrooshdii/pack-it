using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects.PackingItem
{
    public record PackingItemName
    {
        public string Value { get; }

        public PackingItemName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyPackingListItemNameException();
            }

            Value = name;
        }

        public static implicit operator string(PackingItemName name)
            => name.Value;

        public static implicit operator PackingItemName(string value)
            => new(value);
    }
}
