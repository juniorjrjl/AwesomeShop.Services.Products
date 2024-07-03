using AwesomeShop.Services.Products.Core.Repositories;
using AwesomeShop.Services.Products.Infrastructure.Persistence;
using AwesomeShop.Services.Products.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace AwesomeShop.Services.Products.Infrastructure;

public static class Extensions
{
    
    public static IServiceCollection AddMongo(this IServiceCollection services) {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        #pragma warning disable CS0618
        BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
        #pragma warning restore CS0618

        services.AddSingleton(s => {
            var configuration = s.GetService<IConfiguration>();
            ArgumentNullException.ThrowIfNull(configuration);
            var mongoConfig = configuration.GetSection("Mongo").Get<MongoDbOptions>();
            ArgumentNullException.ThrowIfNull(mongoConfig);

            return mongoConfig;
        });

        services.AddSingleton<IMongoClient>(sp => {
            var options = sp.GetService<MongoDbOptions>();
            ArgumentNullException.ThrowIfNull(options);
            return new MongoClient(options.ConnectionString);
        });

        services.AddTransient(sp => {
            var options = sp.GetService<MongoDbOptions>();
            var mongoClient = sp.GetService<IMongoClient>();
            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(mongoClient);
            return mongoClient.GetDatabase(options.Database);
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

}