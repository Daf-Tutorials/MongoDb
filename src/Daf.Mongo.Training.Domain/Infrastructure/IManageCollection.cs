using System.Linq.Expressions;
using Daf.Mongo.Training.Domain.Models;
using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IManageCollection<T> where T: class
{
  string DatabaseName { get; }
  string CollectionName { get; }
  Task<IEnumerable<Account>> GetAll();
  IMongoCollection<T> GetCollection();
  void InsertOne(T entity);
  void InsertMany(IEnumerable<T> entities);
  Task InsertOneAsync(T entity);
  Task InsertManyAsync(IEnumerable<T> entities);
  Task<UpdateResult> Update(Expression<Func<T, bool>> predicate, UpdateDefinition<T> updateDefinition);
  Task<UpdateResult> UpdateMany(Expression<Func<T, bool>> predicate, UpdateDefinition<T> updateDefinition);
}