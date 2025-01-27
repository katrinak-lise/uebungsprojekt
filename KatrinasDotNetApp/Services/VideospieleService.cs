using KatrinasDotNetApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KatrinasDotNetApp.Services;

public class VideospieleService
{
    private readonly IMongoCollection<Videospiel> _videospieleCollection;

    public VideospieleService(
        IOptions<VideospieleDatabaseSettings> videospieleDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            videospieleDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            videospieleDatabaseSettings.Value.DatabaseName);

        _videospieleCollection = mongoDatabase.GetCollection<Videospiel>(
            videospieleDatabaseSettings.Value.VideospieleCollectionName);
    }

    public async Task<List<Videospiel>> GetAsync() =>
        await _videospieleCollection.Find(_ => true).ToListAsync();

    public async Task<Videospiel?> GetAsync(ObjectId id) =>
        await _videospieleCollection.Find(x => Equals(x.Id, id)).FirstOrDefaultAsync();

    public async Task CreateAsync(Videospiel neuesVideospiel) =>
        await _videospieleCollection.InsertOneAsync(neuesVideospiel);

    public async Task UpdateAsync(ObjectId id, Videospiel aktualisiertesVideospiel) =>
        await _videospieleCollection.ReplaceOneAsync(x => Equals(x.Id, id), aktualisiertesVideospiel);

    public async Task RemoveAsync(ObjectId id) =>
        await _videospieleCollection.DeleteOneAsync(x => Equals(x.Id, id));
    
    
}