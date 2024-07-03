using MediatR;

namespace AwesomeShop.Services.Products.Application.Commands;

public record UpdateProduct(Guid Id, string Description, decimal Price, CategoryDTO Category): IRequest;