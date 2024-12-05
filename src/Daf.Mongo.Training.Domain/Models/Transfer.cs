using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Daf.Mongo.Training.Domain.Models;

public class Transfer
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]     
  public string Id { get; set; }
     
  [BsonElement("transfer_id")]
  public string TransferId { get; set; }

  [BsonElement("to_account")]
  public string ToAccount { get; set; }

  [BsonElement("from_account")]
  public string FromAccount { get; set; } 

  [BsonRepresentation(BsonType.Decimal128)]
  [BsonElement("amount")]
  public decimal Amount { get; set; }

}