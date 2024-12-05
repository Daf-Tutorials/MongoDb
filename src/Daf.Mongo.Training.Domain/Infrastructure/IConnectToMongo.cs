using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IConnectToMongo
{
  IEnumerable<MongoDB.Bson.BsonDocument> GetDatabases();
  IMongoDatabase GetDatabase(string databaseName);
}