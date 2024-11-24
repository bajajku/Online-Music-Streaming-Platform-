using Microsoft.AspNetCore.Mvc;

public class PlaylistController : Controller
{
    public IActionResult Index()
    {
        var playlists = new List<string> { "Playlist 1", "Playlist 2", "Playlist 3" };
        var model = new
        {
            Username = "SampleUser",
            Playlists = playlists
        };
        return View(model);
    }
}
