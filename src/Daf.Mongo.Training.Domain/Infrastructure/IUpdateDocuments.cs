using System.Linq.Expressions;
using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IUpdateDocuments<T> : IIdentifyCollection<T>
{
  Task<UpdateResult> Update(Expression<Func<T, bool>> predicate, UpdateDefinition<T> updateDefinition);
  Task<UpdateResult> UpdateMany(Expression<Func<T, bool>> predicate, UpdateDefinition<T> updateDefinition);
}