using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotelWebApp.Models
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement]
        public string? Naziv { get; set; }
        public decimal? Cena { get; set; }
        public string? Adresa { get; set; }
        public int? BrojKreveta { get; set; }
        public string? Grad { get; set; }
        public string? Opis { get; set; }
        public string? Zemlja { get; set; }
        public List<string>? Slike { get; set; }

        public static IMongoCollection<Room> _rooms;
    }
}
