using Daf.Mongo.Training.Domain.Infrastructure;
using MongoDB.Driver;

namespace Daf.Mongo.Training.Infra;

internal class MongoDriver : IConnectToMongo
{
  private const string ConnectionString =
    "mongodb+srv://dafdev:jpHtRY3vM6bvNK7O@normal.aycpm.mongodb.net/?retryWrites=true&w=majority&appName=Normal";

  private readonly MongoClient _client = new(ConnectionString);

  public IEnumerable<MongoDB.Bson.BsonDocument> GetDatabases()
    => _client.ListDatabases().ToList();

  public IMongoDatabase GetDatabase(string databaseName)
  {
    return _client.GetDatabase(databaseName);
  }
}
