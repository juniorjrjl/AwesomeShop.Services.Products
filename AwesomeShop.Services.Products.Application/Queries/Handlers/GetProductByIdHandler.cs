using AwesomeShop.Services.Products.Application.DTOs.ViewModes;
using AwesomeShop.Services.Products.Application.Mappers;
using AwesomeShop.Services.Products.Core.Repositories;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Queries.Handlers;

public class GetProductByIdHandler(IProductRepository repository, IProductMapper mapper) : IRequestHandler<GetProductById, ProductDetailsViewModel>
{
    private readonly IProductRepository _repository = repository;

    public async Task<ProductDetailsViewModel> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        return mapper.ToProductDetailsViewModel(product);
    }

}
