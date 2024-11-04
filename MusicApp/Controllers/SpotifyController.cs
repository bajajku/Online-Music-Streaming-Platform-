using Microsoft.AspNetCore.Mvc;
using SpotifyMVC.Services;
using System.Threading.Tasks;

namespace SpotifyMVC.Controllers
{
    public class SpotifyController : Controller
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        public async Task<IActionResult> Index()
        {
            var featuredPlaylists = await _spotifyService.GetFeaturedPlaylistsAsync();
            var newReleases = await _spotifyService.GetNewReleasesAsync();
            return View((featuredPlaylists, newReleases));
        }

        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return View(new List<string>());

            var tracks = await _spotifyService.SearchTracksAsync(query);
            return View(tracks);
        }

        public async Task<IActionResult> Track(string id)
        {
            var track = await _spotifyService.GetTrackAsync(id);
            return View(track);
        }

        public async Task<IActionResult> ArtistTopTracks(string id)
        {
            var tracks = await _spotifyService.GetArtistTopTracksAsync(id);
            return View(tracks);
        }

        public async Task<IActionResult> PlaylistTracks(string id)
        {
            var tracks = await _spotifyService.GetPlaylistTracksAsync(id);
            return View(tracks);
        }

        public async Task<IActionResult> Categories()
        {
            var categories = await _spotifyService.GetCategoriesAsync();
            return View(categories);
        }
    }
}