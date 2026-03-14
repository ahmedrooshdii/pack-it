using PackIt.Domain.ValueObjects.PackingList;
using PackIt.Shared.Abstractions.Exceptions;

namespace PackIt.Application.Exceptions
{
    public class MissingLocalizationWeatherException : PackItException
    {
        public Localization Localization { get; }

        public MissingLocalizationWeatherException(Localization localization)
            : base($"Couldn't fetch weather for localization {localization.Country}/{localization.City}.")
        {
            Localization = localization;
        }
    }
}
