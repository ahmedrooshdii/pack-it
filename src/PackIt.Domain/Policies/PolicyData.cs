using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Policies
{
    public record PolicyData(TravelDays Days, Consts.Gender Gender, Temperature Temperature, Localization Localization);
}
