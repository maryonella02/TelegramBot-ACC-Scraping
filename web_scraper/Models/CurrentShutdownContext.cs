using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class CurrentShutdownContext
{
    private readonly IMongoDatabase _database = null;

    public CurrentShutdownContext(IOptions settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        if (client != null)
            _database = client.GetDatabase(settings.Value.Database);
    }

    public IMongoCollection Shutdowns
    {
        get
        {
            return _database.GetCollection("Current Shutdown");
        }
    }
}