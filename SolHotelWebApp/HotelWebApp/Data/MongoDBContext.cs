using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HotelWebApp.Models;

namespace HotelWebApp.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDBContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Room> Rooms
        {
            get
            {
                return _database.GetCollection<Room>("HotelAppCollection");
            }
        }

        public class Settings
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
    }
}
