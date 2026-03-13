using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Domain.Exceptions
{
    public class InvalidTemperatureException : PackItException
    {
        public double Temperature { get; }
        public InvalidTemperatureException(double temperature)
            : base($"Value '{temperature}' is invalid temperature.")
        {
            Temperature = temperature;
        }
    }
}
