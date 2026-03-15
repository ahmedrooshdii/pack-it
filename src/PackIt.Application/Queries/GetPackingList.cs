using PackIt.Application.DTOs;
using PackIt.Shared.Abstractions.Queries;

namespace PackIT.Application.Queries
{
    public record GetPackingList(Guid Id) : IQuery<PackingListDto>;
}
