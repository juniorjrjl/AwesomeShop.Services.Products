namespace AwesomeShop.Services.Products.Application.DTOs.ViewModes;

public record ProductDetailsViewModel(Guid Id, string Title, string Description, decimal Price, int Amount);