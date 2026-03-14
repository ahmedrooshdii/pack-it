using PackIt.Application.Utilities;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects.PackingItem;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers
{
    public sealed class AddPackingItemHandler : ICommandHandler<AddPackingItem>
    {
        private readonly IPackingListRepository _repository;

        public AddPackingItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(AddPackingItem command, CancellationToken cancellationToken = default)
        {
            var packingList = await _repository.GetOrThrowAsync(command.PackingListId);

            var packingItem = new PackingItem(command.Name, command.Quantity);
            packingList.AddItem(packingItem);

            await _repository.UpdateAsync(packingList);
        }
    }
}
