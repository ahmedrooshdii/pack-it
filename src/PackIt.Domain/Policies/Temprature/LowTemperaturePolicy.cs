using PackIt.Domain.Policies;
using PackIt.Domain.ValueObjects.PackingItem;

namespace PackIt.Domain.Policies.Temprature
{
    internal sealed class LowTemperaturePolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Temperature < 10D;
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
            new PackingItem("Warm Jacket", 1),
            new PackingItem("Sweater", 2),
            new PackingItem("Scarf", 1),
            new PackingItem("Gloves", 1),
            new PackingItem("Warm jacket", 1),
            new PackingItem("Thermal Underwear", 2)
            };
    }
}
