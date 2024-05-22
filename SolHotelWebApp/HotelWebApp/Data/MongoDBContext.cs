using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HotelWebApp.Models;
using System.Runtime;
using HotelWebApp.Interfaces;

namespace HotelWebApp.Data
{
    public class MongoDBContext // : IRoom
    {
        public readonly IMongoDatabase _db;
        public MongoDBContext(IOptions<DBSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Room> rooms => _db.GetCollection<Room>("HotelAppCollection");
    }
}
