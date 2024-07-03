using Amazon.Runtime.Internal;
using AwesomeShop.Services.Products.Application.DTOs.ViewModes;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Queries;

public record GetProductById(Guid Id) : IRequest<ProductDetailsViewModel>;