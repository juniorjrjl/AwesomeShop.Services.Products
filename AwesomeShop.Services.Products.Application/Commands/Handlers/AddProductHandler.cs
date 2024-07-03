using AwesomeShop.Services.Products.Application.Mappers;
using AwesomeShop.Services.Products.Core.Repositories;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Commands.Handlers;

public class AddProductHandler(IProductRepository repository, IProductMapper mapper) : IRequestHandler<AddProduct, Guid>
{
    private readonly IProductRepository _repository = repository;
    private readonly IProductMapper _mapper = mapper;

    public async Task<Guid> Handle(AddProduct request, CancellationToken cancellationToken)
    {
        var product =  _mapper.ToProduct(request);
        await _repository.AddAsync(product);
        return product.Id;
    }

}
