namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IInsertDocuments<in T>
{
  Task InsertOneAsync(T entity);
  Task InsertManyAsync(IEnumerable<T> entities);
}