// namespace Daf.Mongo.Training.App;
//
// public class TransferService
// {
//   public void Execute(string fromId, string toId, decimal transferAmount, string? transferId = null)
//   {
//     using (var session = client.StartSession())
//     {
//       // Define the sequence of operations to perform inside the transactions
//       session.WithTransaction(
//         (s, ct) =>
//         {
//           // var fromId = "MDB310054629";
//           // var toId = "MDB546986470";
//
//           // Create the transfer_id and amount being transfered
//           transferId ??= "TR02081994";
//           // var transferAmount = 20;
//
//           // Obtain the account that the money will be coming from
//           var fromAccountResult = accountsCollection.Find(e => e.AccountId == fromId).FirstOrDefault();
//           // Get the balance and id of the account that the money will be coming from
//           var fromAccountBalance = fromAccountResult.Balance - transferAmount;
//           var fromAccountId = fromAccountResult.AccountId;
//
//           Console.WriteLine(fromAccountBalance.GetType());
//
//           // Obtain the account that the money will be going to
//           var toAccountResult = accountsCollection.Find(e => e.AccountId == toId).FirstOrDefault();
//           // Get the balance and id of the account that the money will be going to
//           var toAccountBalance = toAccountResult.Balance + transferAmount;
//           var toAccountId = toAccountResult.AccountId;
//
//           // Create the transfer record
//           var transferDocument = new Transfer
//           {
//             TransferId = transferId,
//             ToAccount = toAccountId,
//             FromAccount = fromAccountId,
//             Amount = transferAmount
//           };
//
//           // Update the balance and transfer array for each account
//           var fromAccountUpdateBalance = Builders<Accounts>.Update.Set("balance", fromAccountBalance);
//           var fromAccountFilter = Builders<Accounts>.Filter.Eq("account_id", fromId);
//           accountsCollection.UpdateOne(fromAccountFilter, fromAccountUpdateBalance);
//
//           var fromAccountUpdateTransfers = Builders<Accounts>.Update.Push("transfers_complete", transferId);
//           accountsCollection.UpdateOne(fromAccountFilter, fromAccountUpdateTransfers);
//
//           var toAccountUpdateBalance = Builders<Accounts>.Update.Set("balance", toAccountBalance);
//           var toAccountFilter = Builders<Accounts>.Filter.Eq("account_id", toId);
//           accountsCollection.UpdateOne(toAccountFilter, toAccountUpdateBalance);
//           var toAccountUpdateTransfers = Builders<Accounts>.Update.Push("transfers_complete", transferId);
//
//           // Insert transfer doc
//           transfersCollection.InsertOne(transferDocument);
//           Console.WriteLine("Transaction complete!");
//           return "Inserted into collections in different databases";
//         });
//     }
//   }
// }