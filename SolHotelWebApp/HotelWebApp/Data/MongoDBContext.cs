using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HotelWebApp.Interfaces;
using HotelWebApp.Models;

namespace HotelWebApp.Data
{
    public class MongoDBContext : IRoom
    {
        public readonly IMongoDatabase _db;
        public MongoDBContext(IOptions<DBSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Room> rooms => _db.GetCollection<Room>("HotelAppCollection");

        public Room GetRoom(string id)
        {
            return rooms.Find(r => r.Id == id).FirstOrDefault();
        }
        public List<Room> GetAllRooms()
        {
            return rooms.Find(r => true).ToList();
        }

        public void CreateRoom(Room room)
        {
            rooms.InsertOne(room);
        }

        public void UpdateRoom(string id, Room room)
        {
            var filter = Builders<Room>.Filter.Eq(r => r.Id, id);
            var update = Builders<Room>.Update
                .Set("Naziv", room.Naziv)
                .Set("Cena", room.Cena)
                .Set("Adresa", room.Adresa)
                .Set("BrojKreveta", room.BrojKreveta)
                .Set("Grad", room.Grad)
                .Set("Opis", room.Opis)
                .Set("Zemlja", room.Zemlja)
                .Set("Slike", room.Slike);

            rooms.UpdateOne(filter, update);
        }

        public void DeleteRoom(string id)
        {
            var filter = Builders<Room>.Filter.Eq(r => r.Id, id);
            rooms.DeleteOne(filter);
        }
    }
}
