using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IIdentifyCollection<T>
{
  string DatabaseName { get; }
  string CollectionName { get; }
  Task<IEnumerable<T>> GetAll();
  IMongoCollection<T> GetCollection();
}