using Daf.Mongo.Training.Domain.Infrastructure;
using Daf.Mongo.Training.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Daf.Mongo.Training.Domain.DependencyInjection;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddDomain(this IServiceCollection services)
  {
    return services;
  }
}