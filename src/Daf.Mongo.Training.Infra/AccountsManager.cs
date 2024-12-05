using System.Linq.Expressions;
using Daf.Mongo.Training.Domain.Infrastructure;
using Daf.Mongo.Training.Domain.Models;
using MongoDB.Driver;

namespace Daf.Mongo.Training.Infra;

public class AccountsManager : IManageCollection<Account>
{
  public string DatabaseName { get; } = "bank";
  public string CollectionName { get; } = "accounts";
  private readonly IMongoCollection<Account> _accounts;

  public AccountsManager(IConnectToMongo client)
  {
    var database = client.GetDatabase(DatabaseName);
    _accounts = database.GetCollection<Account>(CollectionName);
  }
  
  public IMongoCollection<Account> GetCollection() => _accounts;
  public async Task<IEnumerable<Account>> GetAll() => (await _accounts.FindAsync(_ => true)).ToList();
  
  public void InsertOne(Account entity) => _accounts.InsertOne(entity);
  public void InsertMany(IEnumerable<Account> entities) => _accounts.InsertMany(entities);
  
  public async Task InsertOneAsync(Account entity) => await _accounts.InsertOneAsync(entity);
  public async Task InsertManyAsync(IEnumerable<Account> entities) => await _accounts.InsertManyAsync(entities);
  
  public async Task<UpdateResult> Update(Expression<Func<Account, bool>> predicate, UpdateDefinition<Account> updateDefinition)
    => await _accounts.UpdateOneAsync(predicate, updateDefinition);
  
  public async Task<UpdateResult> UpdateMany(Expression<Func<Account, bool>> predicate, UpdateDefinition<Account> updateDefinition)
    => await _accounts.UpdateManyAsync(predicate, updateDefinition);

}