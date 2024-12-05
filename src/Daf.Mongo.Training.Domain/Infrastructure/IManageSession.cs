using MongoDB.Driver;

namespace Daf.Mongo.Training.Domain.Infrastructure;

public interface IManageSession
{ 
  IClientSession StartSession();
}