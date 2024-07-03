using AwesomeShop.Services.Products.Core.Entities;
using AwesomeShop.Services.Products.Core.Repositories;
using MongoDB.Driver;

namespace AwesomeShop.Services.Products.Infrastructure.Persistence.Repositories;

public class ProductRepository(IMongoDatabase database) : IProductRepository
{
    private readonly IMongoCollection<Product> _collection = database.GetCollection<Product>("products");

    public async Task AddAsync(Product product) => 
        await _collection.InsertOneAsync(product);

    public async Task<List<Product>> GetAllAsync() => 
        await _collection.Find(c => true).ToListAsync();

    public async Task<Product> GetByIdAsync(Guid id) =>
        await _collection.Find(c => c.Id == id).SingleOrDefaultAsync();

    public async Task UpdateAsync(Product product) =>
        await _collection.ReplaceOneAsync(c => c.Id == product.Id, product);
}