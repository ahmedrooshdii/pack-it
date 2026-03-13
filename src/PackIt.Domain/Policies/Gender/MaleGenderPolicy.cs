using PackIt.Domain.Policies;
using PackIt.Domain.ValueObjects.PackingItem;

namespace PackIt.Domain.Policies.Gender
{
    internal class MaleGenderPolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data)
            => data.Gender is Consts.Gender.Male;
        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new PackingItem("Razor", 1),
                new PackingItem("Shaving Cream", 1),
                new PackingItem("Aftershave", 1),
                new PackingItem("Book", (ushort) Math.Ceiling(data.Days / 7m)),
            };
    }
}
