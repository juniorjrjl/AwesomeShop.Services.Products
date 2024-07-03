using AwesomeShop.Services.Products.Application.DTOs.ViewModes;
using AwesomeShop.Services.Products.Core.Repositories;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Queries.Handlers;

public class GetAllProductsHandler(IProductRepository repository) : IRequestHandler<GetAllProducts, List<ProductViewModel>>
{
    private readonly IProductRepository _repository = repository;

    public async Task<List<ProductViewModel>> Handle(GetAllProducts request, CancellationToken cancellationToken) 
    {
        var products = await _repository.GetAllAsync();
        return products
            .Select(p => new ProductViewModel(Id: p.Id, Title: p.Title))
            .ToList();
    }

}
