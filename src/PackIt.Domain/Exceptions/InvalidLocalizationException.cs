using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions
{
    public class InvalidLocalizationException : PackItException
    {
        public InvalidLocalizationException(string value)
            : base($"Invalid localization: '{value}'. Expected format is 'City, Country'.")
        {
        }
    }
}
