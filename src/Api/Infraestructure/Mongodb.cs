using MongoDB.Driver;

namespace HorariosEntrevistas.Api.Infraestructure;
public class MongoDb
{
    private readonly IMongoDatabase _database;

    public MongoDb(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoDatabase Database => _database;
}
