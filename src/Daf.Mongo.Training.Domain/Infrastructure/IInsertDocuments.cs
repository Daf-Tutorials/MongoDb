namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IInsertDocuments<T> : IIdentifyCollection<T>
{
  Task InsertOneAsync(T entity);
  Task InsertManyAsync(IEnumerable<T> entities);
}