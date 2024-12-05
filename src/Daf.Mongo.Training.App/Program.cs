using Daf.Mongo.Training.Domain.DependencyInjection;
using Daf.Mongo.Training.Domain.Infrastructure;
using Daf.Mongo.Training.Domain.Models;
using Daf.Mongo.Training.Infra.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

var services = new ServiceCollection()
  .AddInfra()
  .AddDomain();
var accountsManager  = services.BuildServiceProvider().GetRequiredService<IManageCollection<Account>>();

// You can also use the builders class to filter but I did not implement
// it in my interface
// var filter = Builders<Account>
//   .Filter
//   .Eq(a => a.AccountId, "MDB951086017");
//
// var update = Builders<Account>
//   .Update
//   .Set(a=>a.Balance, 5000);
//
// var result = await accountsManager.Update(acc => acc.AccountId=="MDB829001337", update);
//

var update = Builders<Account>
  .Update
  .Inc("balance", 60000);

var result = await accountsManager
  .UpdateMany(acc => acc.Balance < 60000000, update);

if (result.IsAcknowledged)
  Console.WriteLine(result.ModifiedCount);

// var newAccount = new Account
// {
//   AccountId = "MDB829001337",
//   AccountHolder = "Linus Torvalds",
//   AccountType = "checking",
//   Balance = 50352434
// };
// var accountA = new Account
// {
//   AccountId = "MDB829001356",
//   AccountHolder = "Robert C. Martin",
//   AccountType = "checking",
//   Balance = 503577764
// };
//
// var accountB = new Account
// {
//   AccountId = "MDB011235813",
//   AccountHolder = "Ada Lovelace",
//   AccountType = "checking",
//   Balance = 60218
// };
// await accountsManager.InsertOneAsync(newAccount);
// await accountsManager.InsertManyAsync([accountA, accountB]);
// var accountsList = await accountsManager.GetAll();
// Console.WriteLine("Listing accounts");
//
// accountsList.ToList().ForEach(acc => Console.WriteLine(acc.AccountHolder));