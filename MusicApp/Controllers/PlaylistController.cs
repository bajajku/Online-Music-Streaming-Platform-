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

    public IActionResult ViewPlaylist(int id)
    {
        // Simulate fetching the playlist details by ID
        var playlist = new Playlist
        {
            PlaylistId = id,
            Name = $"Playlist {id}",
            Songs = new List<Song>
        {
            new Song { SongId = 1, Title = "Song 1", Artist = "Artist 1", Duration = TimeSpan.FromMinutes(3) },
            new Song { SongId = 2, Title = "Song 2", Artist = "Artist 2", Duration = TimeSpan.FromMinutes(4) }
        }
        };

        return View(playlist); // Pass the playlist to the view
    }

}
