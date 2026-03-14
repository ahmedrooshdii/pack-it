using PackIt.Application.Utilities;
using PackIt.Domain.Repositories;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands.Handlers
{
    public sealed class DeletePackingListHandler : ICommandHandler<DeletePackingList>
    {
        private readonly IPackingListRepository _repository;

        public DeletePackingListHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(DeletePackingList command, CancellationToken cancellationToken = default)
        {
            await _repository.GetOrThrowAsync(command.PackingListId);

            await _repository.DeleteAsync(command.PackingListId);
        }
    }
}
