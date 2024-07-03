namespace AwesomeShop.Services.Products.Core.Events;

public record ProductUpdated(Guid Id) : IDomainEvent;
