using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Application.Exceptions
{
    public class PackingListNotFoundException : PackItException
    {
        public Guid Id { get; }

        public PackingListNotFoundException(Guid id) : base($"Packing List with ID '{id}' not found.")
        {
            Id = id;
        }
    }
}
