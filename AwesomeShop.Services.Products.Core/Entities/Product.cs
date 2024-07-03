using AwesomeShop.Services.Products.Core.Events;
using AwesomeShop.Services.Products.Core.ValuesObjects;

namespace AwesomeShop.Services.Products.Core.Entities;

public class Product : AggregateRoot
{
    public Product(string title, string description, decimal price, int amount, Category category)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Price = price;
        Amount = amount;
        Category = category;
        CreatedAt = DateTime.Now;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int Amount { get; private set; }
    public Category Category { get; private set; }

    public static Product Create(string title, string description, decimal price, int amount, Category category) =>
        new(title, description, price, amount, category);

    public Product Update(string description, decimal price, Category? category)
    {
        if (category is not null)
        {
            Category = category;
        }
        Description = description;
        Price = price;

        AddEvent(new ProductUpdated(Id));
        return this;
    }

}