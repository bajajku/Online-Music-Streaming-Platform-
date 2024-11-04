using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MusicApp.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Index()
        {
            var playlists = new List<string> { "Playlist 1", "Playlist 2", "Playlist 3", "Playlist 4" };
            var model = new
            {
                Username = "SampleUser",
                UserID = "12345",
                Playlists = playlists
            };
            return View(model);
        }
    }
}
