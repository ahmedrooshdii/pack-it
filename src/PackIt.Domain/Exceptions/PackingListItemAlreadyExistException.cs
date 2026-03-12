using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions
{
    public class PackingListItemAlreadyExistException : PackItException
    {
        public string ListName { get; }
        public string ItemName { get; }

        public PackingListItemAlreadyExistException(string listName, string itemName)
            : base($"Packing list item '{itemName}' already exists in packing list '{listName}'.")
        {
            ListName = listName;
            ItemName = itemName;
        }

    }
}
