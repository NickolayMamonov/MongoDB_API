using Microsoft.Extensions.Options;
using MongoDB_API.Models;
using MongoDB.Driver;

namespace MongoDB_API.Services;

public class VideocardService
{
    private readonly IMongoCollection<Videocard> _collection;

    public VideocardService(IOptions<VideocardsDatabaseSettings> videocardsDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            videocardsDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            videocardsDatabaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Videocard>(
            videocardsDatabaseSettings.Value.VideocardsCollectionName);
    }
    
    public async Task<List<Videocard>> GetVideocardsAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<Videocard?> GetVideocardByIdAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateNewVideocardAsync(Videocard videocard) =>
        await _collection.InsertOneAsync(videocard);

    public async Task UpdateVideocardAsync(Videocard videocard) =>
        await _collection.ReplaceOneAsync(x => x.Id == videocard.Id, videocard);

    public async Task DeleteVideocardAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}