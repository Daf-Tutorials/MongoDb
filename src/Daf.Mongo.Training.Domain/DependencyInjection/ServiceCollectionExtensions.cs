using Daf.Mongo.Training.Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Mongo.Training.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddDomain(this IServiceCollection services)
  {
    services.AddSingleton<IConnectToMongo, MongoDriver>();
    return services;
  }
}