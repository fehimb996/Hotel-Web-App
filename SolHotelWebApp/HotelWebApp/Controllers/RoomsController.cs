using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HotelWebApp.Data;
using HotelWebApp.Models;
using MongoDB.Driver;

namespace HotelWebApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly MongoDBContext _context;

        public RoomsController(MongoDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.Find(_ => true).ToListAsync();
            return View(rooms);
        }
    }
}
