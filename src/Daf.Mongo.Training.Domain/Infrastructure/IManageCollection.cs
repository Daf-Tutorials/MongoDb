using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IManageCollection<T> : IInsertDocuments<T>, IUpdateDocuments<T>, IDeleteDocuments<T>
{
  T GetById(string fromId);
}