namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IConnectToMongo
{
  IEnumerable<MongoDB.Bson.BsonDocument> GetDatabases();
}