using AwesomeShop.Services.Products.Application.Mappers;
using AwesomeShop.Services.Products.Core.Repositories;
using MediatR;

namespace AwesomeShop.Services.Products.Application.Commands.Handlers;

public class UpdateProductHandler(IProductRepository repository, IProductMapper mapper) : IRequestHandler<UpdateProduct>
{
    private readonly IProductRepository _repository = repository;

    private readonly IProductMapper _mapper = mapper;

    public async Task Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        product = _mapper.ToProduct(product, request);
        await _repository.UpdateAsync(product);
    }
}