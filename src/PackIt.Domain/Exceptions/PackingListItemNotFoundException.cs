using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions
{
    public class PackingListItemNotFoundException : PackItException
    {
        public string ItemName { get; }

        public PackingListItemNotFoundException(string itemName)
            : base($"Packing list item '{itemName}' was not found.")
        {
            ItemName = itemName;
        }

    }
}
