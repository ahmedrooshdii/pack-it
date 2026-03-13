using PackIt.Domain.Consts;
using PackIt.Domain.Entities;
using PackIt.Domain.Policies;
using PackIt.Domain.ValueObjects.PackingList;

namespace PackIt.Domain.Factories
{
    public class PackingListFactory : IPackingListFactory
    {
        public IEnumerable<IPackingItemsPolicy> _polices;

        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
            => new PackingList(id, name, localization);

        public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender, Temperature temperature, Localization localization)
        {
            var data = new PolicyData(days, gender, temperature, localization);
            var applicablePolices = _polices.Where(p => p.IsApplicable(data));

            var items = applicablePolices.SelectMany(p => p.GenerateItems(data));
            var packingList = Create(id, name, localization);

            packingList.AddItems(items);
            return packingList;
        }
    }
}
