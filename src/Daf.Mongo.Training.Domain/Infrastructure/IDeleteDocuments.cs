using System.Linq.Expressions;
using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IDeleteDocuments<T> : IIdentifyCollection<T>
{
  Task<DeleteResult> Delete(Expression<Func<T, bool>> predicate);
  Task<DeleteResult> DeleteMany(Expression<Func<T, bool>> predicate);
}