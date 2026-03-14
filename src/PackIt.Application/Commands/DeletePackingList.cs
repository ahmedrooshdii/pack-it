using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands
{
    public record DeletePackingList(Guid PackingListId, string Name) : ICommand;
}
