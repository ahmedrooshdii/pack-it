using PackIt.Application.DTOs;
using PackIt.Shared.Abstractions.Queries;

namespace PackIT.Application.Queries
{
    public record SearchPackingLists(string? SearchPhrase) : IQuery<IEnumerable<PackingListDto>>;
}
