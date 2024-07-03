using AwesomeShop.Services.Products.Core.Events;

namespace AwesomeShop.Services.Products.Core.Entities;

public abstract class AggregateRoot : IEntityBase
{
    private List<IDomainEvent> _events = [];
    public Guid Id { get; protected set; }

    public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event)
    {
        _events ??= [];
        _events.Add(@event);
    }
}