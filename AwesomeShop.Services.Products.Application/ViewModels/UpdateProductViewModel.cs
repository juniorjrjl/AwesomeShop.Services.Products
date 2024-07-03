using AwesomeShop.Services.Products.Application.Commands;

namespace AwesomeShop.Services.Products.Application.ViewModels;

public record UpdateProduct(string Description, decimal Price, CategoryDTO Category);