using AwesomeShop.Services.Products.Application.Commands;
using AwesomeShop.Services.Products.Application.DTOs.ViewModes;
using AwesomeShop.Services.Products.Core.Entities;
using AwesomeShop.Services.Products.Core.ValuesObjects;

namespace AwesomeShop.Services.Products.Application.Mappers;

public class ProductMapper : IProductMapper
{

    public ProductDetailsViewModel ToProductDetailsViewModel(Product product) =>
        new(Id: product.Id, 
            Title: product.Title, 
            Description: product.Description, 
            Price: product.Price, 
            Amount: product.Amount
        );

    public Product ToProduct(AddProduct request) =>
        Product.Create(
            title: request.Title, 
            description: request.Description, 
            price: request.Price, 
            amount: 
            request.Amount, 
            category: ToCategory(request.Category)
        );

    public Product ToProduct(Product entity, UpdateProduct request) =>
        entity.Update(description: request.Description, price: request.Price, ToCategory(request.Category));

    private static Category ToCategory(CategoryDTO dto) =>
        new (Description: dto.Description, SubCategory: dto.SubCategory);
}
