using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HotelWebApp.Models;

namespace HotelWebApp.Data
{
    public class MongoDBContext
    {
        public readonly IMongoDatabase _db;
        public MongoDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Room> apartmentsCollection => _db.GetCollection<Room>("Rooms");

        public class Settings
        {
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
    }
}
