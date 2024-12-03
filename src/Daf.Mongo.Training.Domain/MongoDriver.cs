using MongoDB.Driver;
namespace Daf.Mongo.Training.Domain;

public class MongoDriver
{
    private const string ConnectionString =
        "mongodb+srv://dafdev:jpHtRY3vM6bvNK7O@normal.aycpm.mongodb.net/?retryWrites=true&w=majority&appName=Normal";
    private readonly MongoClient _client = new(ConnectionString);

    public IEnumerable<MongoDB.Bson.BsonDocument> GetDatabases() 
        => _client.ListDatabases().ToList();
}
