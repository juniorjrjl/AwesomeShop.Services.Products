namespace AwesomeShop.Services.Products.Core.Events;

public record ProductCreated(Guid Id, string Description) : IDomainEvent;
