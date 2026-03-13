using PackIt.Domain.Policies;
using PackIt.Domain.ValueObjects.PackingItem;

namespace PackIt.Domain.Policies.Universal
{
    internal sealed class BasicPolicy : IPackingItemsPolicy
    {
        private const uint MaximumQuantityOfClothes = 7;

        public bool IsApplicable(PolicyData _)
            => true;

        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
            new PackingItem ("Underwear",  (ushort) Math.Min(data.Days, MaximumQuantityOfClothes)),
            new PackingItem ("Socks", (ushort) Math.Min(data.Days, MaximumQuantityOfClothes)),
            new PackingItem ("T-Shirts", (ushort) Math.Min(data.Days, MaximumQuantityOfClothes)),
            new PackingItem ("Trousers", data.Days < 7 ? (ushort) 1 : (ushort) 2),
            new PackingItem ("Shampoo", 1),
            new PackingItem ("Toothbrush", 1),
            new PackingItem ("Toothpaste", 1),
            new PackingItem ("Towel", 1),
            new PackingItem ("Bag pack", 1),
            new PackingItem ("Phone charger", 1),
            new PackingItem ("Passport", 1),
            };
    }
}
