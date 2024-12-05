using Daf.Mongo.Training.Domain.Infrastructure;
using Daf.Mongo.Training.Domain.Models;
using MongoDB.Driver;

namespace Daf.Mongo.Training.App;

public class TransferService(
  IManageSession sessionManager,
  IInsertDocuments<Transfer> transfers,
  IManageCollection<Account> accounts)
{
  public async Task Execute(string fromId, string toId, decimal transferAmount, string? transferId = null)
  {
    using var session = sessionManager.StartSession();
    // Define the sequence of operations to perform inside the transactions
    session.StartTransaction();
    // var fromId = "MDB310054629";
    // var toId = "MDB546986470";

    // Create the transfer_id and amount being transfered
    transferId ??= "TR02081994";
    // var transferAmount = 20;

    // Obtain the account that the money will be coming from
    var fromAccountResult = accounts.GetById(fromId);
    // Get the balance and id of the account that the money will be coming from
    var fromAccountBalance = fromAccountResult.Balance - transferAmount;
    var fromAccountId = fromAccountResult.AccountId;

    Console.WriteLine(fromAccountBalance.GetType());

    // Obtain the account that the money will be going to
    var toAccountResult = accounts.GetById(toId);
    // Get the balance and id of the account that the money will be going to
    var toAccountBalance = toAccountResult.Balance + transferAmount;
    var toAccountId = toAccountResult.AccountId;

    // Create the transfer record
    var transferDocument = new Transfer
    {
      TransferId = transferId,
      ToAccount = toAccountId,
      FromAccount = fromAccountId,
      Amount = transferAmount
    };

    // Update the balance and transfer array for each account
    var fromAccountUpdateBalance = Builders<Account>.Update.Set("balance", fromAccountBalance);
    await accounts.Update(acc => acc.AccountId == fromAccountId, fromAccountUpdateBalance);

    var fromAccountUpdateTransfers = Builders<Account>.Update.Push("transfers_complete", transferId);
    await accounts.Update(acc => acc.AccountId == fromAccountId, fromAccountUpdateTransfers);

    var toAccountUpdateBalance = Builders<Account>.Update.Set("balance", toAccountBalance);
    await accounts.Update(acc => acc.AccountId == toAccountId, toAccountUpdateBalance);
    var toAccountUpdateTransfers = Builders<Account>.Update.Push("transfers_complete", transferId);
    await accounts.Update(acc => acc.AccountId == toAccountId, toAccountUpdateBalance);

    // Insert transfer doc
    await transfers.InsertOneAsync(transferDocument);
    Console.WriteLine("Transaction complete!");
  }
}