using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions
{
    public class EmptyPackingListNameException : PackItException
    {
        public EmptyPackingListNameException()
            : base("Packing list name cannot be empty.")
        {
        }
    }
}
