using AwesomeShop.Services.Products.Application.Commands;
using AwesomeShop.Services.Products.Application.DTOs.ViewModes;
using AwesomeShop.Services.Products.Core.Entities;

namespace AwesomeShop.Services.Products.Application.Mappers;

public interface IProductMapper
{
    
    ProductDetailsViewModel ToProductDetailsViewModel(Product product);

    Product ToProduct(AddProduct request);

    Product ToProduct(Product entity, UpdateProduct request);

}