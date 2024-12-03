using Daf.Mongo.Training.Domain;

var client = new MongoDriver();
var dbList = client.GetDatabases().ToList();

Console.WriteLine("Listing databases");
dbList.ForEach(Console.WriteLine);