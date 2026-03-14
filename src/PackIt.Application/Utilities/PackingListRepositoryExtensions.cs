using PackIt.Application.Exceptions;
using PackIt.Domain.Entities;
using PackIt.Domain.Repositories;

namespace PackIt.Application.Utilities
{
    public static class PackingListRepositoryExtensions
    {
        public static async Task<PackingList> GetOrThrowAsync(
            this IPackingListRepository repository,
            Guid packingListId)
        {
            var packingList = await repository.GetAsync(packingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(packingListId);
            }

            return packingList;
        }
    }
}
