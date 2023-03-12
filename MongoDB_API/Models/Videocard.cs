using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_API.Models;


public class Videocard
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("vendor")]
    [BsonRepresentation(BsonType.String)]
    public string Vendor { get; set; } = null!;
    
    [BsonElement("name")]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; } = null!;
    
    [BsonElement("capacity")]
    [BsonRepresentation(BsonType.Int32)]
    public int Capacity { get; set; }
    
    [BsonElement("index")]
    [BsonRepresentation(BsonType.Int32)]
    [JsonIgnore]
    public int Index { get; set; }
}