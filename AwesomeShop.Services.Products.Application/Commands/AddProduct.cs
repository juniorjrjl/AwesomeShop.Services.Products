using MediatR;

namespace AwesomeShop.Services.Products.Application.Commands;

public record AddProduct(string Title, string Description, decimal Price, int Amount, CategoryDTO Category): IRequest<Guid>;