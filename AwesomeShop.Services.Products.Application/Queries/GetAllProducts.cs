using AwesomeShop.Services.Products.Application.DTOs.ViewModes;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Queries;

public record GetAllProducts() : IRequest<List<ProductViewModel>>;