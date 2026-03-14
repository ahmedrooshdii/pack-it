using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands
{
    public record PackItem(Guid PackingListId, string Name, ushort Quantity) : ICommand;
}
