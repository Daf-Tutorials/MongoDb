using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IConnectToMongo
{
  IMongoClient Client { get; }
  IEnumerable<MongoDB.Bson.BsonDocument> GetDatabases();
  IMongoDatabase GetDatabase(string databaseName);
}