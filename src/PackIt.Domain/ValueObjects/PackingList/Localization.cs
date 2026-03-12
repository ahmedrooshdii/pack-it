using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects.PackingList
{
    public record Localization(string City, string Country)
    {
        public static Localization Create(string value)
        {
            var splitLocalization = value.Split(',');
            if (splitLocalization.Length != 2)
            {
                throw new InvalidLocalizationException(value);
            }

            return new Localization(splitLocalization.First().Trim(), splitLocalization.Last().Trim());
        }

        public static implicit operator string(Localization localization)
            => $"{localization.City}, {localization.Country}";

        public static implicit operator Localization(string value)
            => Create(value);

        public override string ToString()
            => $"{City}, {Country}";
    }
}
