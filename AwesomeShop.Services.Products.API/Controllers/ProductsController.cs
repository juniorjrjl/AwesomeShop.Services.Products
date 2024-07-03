using AwesomeShop.Services.Products.Application.Commands;
using AwesomeShop.Services.Products.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeShop.Services.Products.API.Controllers;

[Route("api/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{

    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllProducts();

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetProductById(id);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddProduct command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProduct viewModel)
    {
        var command = new UpdateProduct(Id: id, Description: viewModel.Description, Price: viewModel.Price, Category: viewModel.Category);
        await _mediator.Send(command);

        return Ok(command);
    }

}