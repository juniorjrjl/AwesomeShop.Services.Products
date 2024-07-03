namespace AwesomeShop.Services.Products.Infrastructure.Persistence;

public record MongoDbOptions(string ConnectionString, string Database);