using HotelWebApp.Models;
using MongoDB.Driver;

namespace HotelWebApp.Interfaces
{
    public interface IRoom
    {
        IMongoCollection<Room> rooms { get; }

        Room GetRoom(string id);

        public List<Room> GetAllRooms();

        void CreateRoom(Room room);

        void UpdateRoom(string id, Room room);

        void DeleteRoom(string id);
    }
}
