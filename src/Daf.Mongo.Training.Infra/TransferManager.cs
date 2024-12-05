using Daf.Mongo.Training.Domain.Infrastructure;
using Daf.Mongo.Training.Domain.Models;
using MongoDB.Driver;

namespace Daf.Mongo.Training.Infra;

public class TransferManager : IIdentifyCollection<Transfer>,IInsertDocuments<Transfer>
{
  public string DatabaseName { get; } = "bank";
  public string CollectionName { get; } = "transfers";
  private readonly IMongoCollection<Transfer> _transfers;

  public TransferManager(IConnectToMongo client)
  {
    var database = client.GetDatabase(DatabaseName);
    _transfers = database.GetCollection<Transfer>(CollectionName);
  }
  
  public async Task<IEnumerable<Transfer>> GetAll() 
    => await _transfers.Find(transfer => true).ToListAsync();

  public IMongoCollection<Transfer> GetCollection() => _transfers;

  public async Task InsertOneAsync(Transfer entity) => await _transfers.InsertOneAsync(entity);

  public async Task InsertManyAsync(IEnumerable<Transfer> entities) => await _transfers.InsertManyAsync(entities);
}