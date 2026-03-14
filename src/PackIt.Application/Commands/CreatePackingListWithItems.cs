using PackIt.Domain.Consts;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Application.Commands
{
    public record CreatePackingListWithItems(Guid Id, string Name, ushort Days, Gender Gender, double Temperature, LocalizationReadModel Localization) : ICommand;

    public record LocalizationReadModel(string City, string Country);
}
