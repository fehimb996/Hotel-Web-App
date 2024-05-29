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

        [HttpGet]
        public async Task<IActionResult> ChangeRoomInfo(string id)
        {
            var oneRoom = _room.GetRoom(id);
            return View("ChangeRoomInfo", oneRoom);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoomInfo(string id, List<IFormFile> ImagePaths)
        {
            Room r = _room.GetRoom(id);

            r.Naziv = Request.Form["Naziv"];
            r.Adresa = Request.Form["Adresa"];
            r.Opis = Request.Form["Opis"];
            r.Grad = Request.Form["Grad"];

            if (r.Slike == null)
            {
                r.Slike = new List<string>();
            }

            foreach (IFormFile file in ImagePaths)
            {
                if (file.Length > 0)
                {
                    var imagesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    var uniqueFileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
                    var filePath = Path.Combine(imagesFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    r.Slike.Add($"/images/{uniqueFileName}");
                }
            }
            r.Zemlja = Request.Form["Zemlja"];
            r.Cena = Convert.ToDecimal(Request.Form["Cena"]);
            r.BrojKreveta = Int32.Parse(Request.Form["BrojKreveta"]);
            _room.UpdateRoom(id, r);

            return RedirectToRoute("roomInfo", new { id = id });
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRoom(string id)
        {
            _room.DeleteRoom(id);

            return RedirectToRoute("allRooms");
        }
    }
}
