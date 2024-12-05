using Daf.Mongo.Training.Domain.Infrastructure;
using Daf.Mongo.Training.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Mongo.Training.Infra.DependencyInjection;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddInfra(this IServiceCollection services)
  {
    services.AddSingleton<IConnectToMongo, MongoDriver>();
    services.AddScoped<IManageSession, MongoSessionManager>();
    services.AddTransient<IManageCollection<Account>, AccountsManager>();
    services.AddTransient<IInsertDocuments<Transfer>, TransferManager>();

    return services;
  }
}