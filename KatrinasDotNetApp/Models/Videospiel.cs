using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KatrinasDotNetApp.Models;

public class Videospiel
{
    [BsonId]
    public ObjectId Id { get; set; }
    
    [BsonElement("Titel")]
    public string? Titel { get; set; }
    public string? Beschreibung { get; set; }
    public string? Entwickler  { get; set; }
    public int Erscheinungsjahr { get; set; }
    public int Bewertung  { get; set; }
    public int Trailer  { get; set; }
    public string? Console { get; set; }
}