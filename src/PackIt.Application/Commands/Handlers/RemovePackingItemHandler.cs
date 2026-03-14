using PackIt.Application.Utilities;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers
{
    public sealed class RemovePackingItemHandler : ICommandHandler<RemovePackingItem>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemovePackingItem command, CancellationToken cancellationToken = default)
        {
            var packingList = await _repository.GetOrThrowAsync(command.PackingListId);

            packingList.RemoveItem(command.Name);
            await _repository.UpdateAsync(packingList);
        }
    }
}
