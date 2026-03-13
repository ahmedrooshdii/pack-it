using PackIt.Domain.Policies;
using PackIt.Domain.ValueObjects.PackingItem;

namespace PackIt.Domain.Policies.Temprature
{
    internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Temperature > 25D;

        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
            new PackingItem("Light T-Shirt", 2),
            new PackingItem("Sunglasses", 1),
            new PackingItem("Cream with UV filter", 1)
            };
    }
}
