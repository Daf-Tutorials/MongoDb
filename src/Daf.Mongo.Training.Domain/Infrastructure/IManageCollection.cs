using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IManageCollection<T> : IIdentifyCollection<T>, IInsertDocuments<T>, IUpdateDocuments<T>, IDeleteDocuments<T>;