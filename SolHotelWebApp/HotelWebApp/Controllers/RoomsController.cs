using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HotelWebApp.Data;
using HotelWebApp.Interfaces;
using HotelWebApp.Models;
using MongoDB.Driver;

namespace HotelWebApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoom _room;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public RoomsController(IRoom room, IWebHostEnvironment hostingEnvironment)
        {
            _room = room;
            _hostingEnvironment = hostingEnvironment;
        }
        
        [HttpGet]
        public async Task<IActionResult> AllRooms()
        {
            var rooms = _room.GetAllRooms();
            return View("Index", rooms);
        }

        [HttpGet]
        public async Task<IActionResult> OneRoom(string id)
        {
            var oneRoom = _room.GetRoom(id);
            return View("RoomInfo", oneRoom);
        }
    }
}
