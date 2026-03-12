using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions
{
    public class IvalidPackingPackingItemQuantityException : PackItException
    {
        public IvalidPackingPackingItemQuantityException()
            : base("Packing item quantity cannot be zero nor less.")
        {
        }
    }
}
