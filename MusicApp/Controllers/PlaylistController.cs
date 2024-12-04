using Microsoft.AspNetCore.Mvc;
using SpotifyMVC.Models;

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
            Id = id.ToString(),
            Name = "My Playlist",
            Description = "A collection of my favorite songs",
            Images = new List<SpotifyImage>
            {
                new SpotifyImage { Url = "https://via.placeholder.com/150" }
            },
            ExternalUrls = new ExternalUrls { Spotify = "https://open.spotify.com/playlist/123" },
            Owner = new PlaylistOwner
            {
                Id = "user123",
                DisplayName = "Sample User",
                ExternalUrls = new ExternalUrls { Spotify = "https://open.spotify.com/user/user123" }
            },
            Public = true,
            Tracks = new PlaylistTracks
            {
                Total = 10,
                Items = new List<PlaylistTrack>
                {
                    new PlaylistTrack
                    {
                        Track = new Track
                        {
                            Id = "track123",
                            Name = "Song 1",
                            Artists = new List<Artist> { new Artist { Name = "Artist 1" } },
                            Album = new Album { Name = "Album 1" },
                            DurationMs = 180000,
                            ExternalUrls = new ExternalUrls { Spotify = "https://open.spotify.com/track/track123" },
                            PreviewUrl = "https://p.scdn.co/mp3-preview/preview.mp3",
                            IsPlayable = true
                        }
                    },
                    new PlaylistTrack
                    {
                        Track = new Track
                        {
                            Id = "track456",
                            Name = "Song 2",
                            Artists = new List<Artist> { new Artist { Name = "Artist 2" } },
                            Album = new Album { Name = "Album 2" },
                            DurationMs = 200000,
                            ExternalUrls = new ExternalUrls { Spotify = "https://open.spotify.com/track/track456" },
                            PreviewUrl = "https://p.scdn.co/mp3-preview/preview.mp3",
                            IsPlayable = true
                        }
                    }
                }
            }
            
        };

        return View(playlist); // Pass the playlist to the view
    }

}
