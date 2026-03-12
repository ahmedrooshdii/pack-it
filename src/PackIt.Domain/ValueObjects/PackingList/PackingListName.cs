using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects.PackingList
{
    public record PackingListName
    {
        public string Value { get; }

        public PackingListName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyPackingListNameException();
            }

            Value = name;
        }

        public static implicit operator string(PackingListName name)
            => name.Value;

        public static implicit operator PackingListName(string value)
            => new PackingListName(value);
    }
}
