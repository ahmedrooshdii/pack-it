using PackIt.Application.Utilities;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers
{
    public sealed class PackItemHandler : ICommandHandler<PackItem>
    {
        private readonly IPackingListRepository _repository;

        public PackItemHandler(IPackingListRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(PackItem command, CancellationToken cancellationToken = default)
        {
            var packingList = await _repository.GetOrThrowAsync(command.PackingListId);

            packingList.PackItem(command.Name);
            await _repository.UpdateAsync(packingList);
        }
    }
}
