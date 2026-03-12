using PackIt.Domain.Entities;
using PackIt.Domain.ValueObjects.PackingItem;
using PackIt.Shared.Abstractions.Domain;

namespace PackIt.Domain.Events
{
    public record PackingItemAddedEvent(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;
}
