using Daf.Mongo.Training.Domain.DependencyInjection;
using Daf.Mongo.Training.Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

var services = new ServiceCollection()
  .AddDomain();
var client  = services.BuildServiceProvider().GetRequiredService<IConnectToMongo>();
var dbList = client.GetDatabases().ToList();

Console.WriteLine("Listing databases");
dbList.ForEach(Console.WriteLine);