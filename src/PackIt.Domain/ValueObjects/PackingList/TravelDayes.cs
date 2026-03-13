using PackIt.Domain.Exceptions;

namespace PackIt.Domain.ValueObjects.PackingList
{
    public record TravelDays
    {
        public ushort Value { get; }
        public TravelDays(ushort value)
        {
            if (value is 0 or > 90)
            {
                throw new InvalidTravelDaysException(value);
            }

            Value = value;
        }

        public static implicit operator ushort(TravelDays travelDays)
            => travelDays.Value;

        public static implicit operator TravelDays(ushort value)
            => new TravelDays(value);
    }
}