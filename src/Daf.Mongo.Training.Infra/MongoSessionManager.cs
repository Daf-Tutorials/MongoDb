using Daf.Mongo.Training.Domain.Infrastructure;
using MongoDB.Driver;

namespace Daf.Mongo.Training.Infra;

public class MongoSessionManager(IConnectToMongo client) : IManageSession
{
  public IClientSession StartSession() => client.Client.StartSession();
}