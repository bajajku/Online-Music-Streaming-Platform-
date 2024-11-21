using Microsoft.AspNetCore.Mvc;
using SpotifyMVC.Services;
using System.Threading.Tasks;


namespace SpotifyMVC.Controllers
{
    [ApiController]
    [Route("api")]
    public class SpotifyController : Controller
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var featuredPlaylists = await _spotifyService.GetFeaturedPlaylistsAsync();
            var newReleases = await _spotifyService.GetNewReleasesAsync();
            return Ok(new { featuredPlaylists, newReleases });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return Ok(new List<string>());

            var tracks = await _spotifyService.SearchTracksAsync(query);
            return Ok(tracks);
        }

        [HttpGet("track")]
        public async Task<IActionResult> Track(string id)
        {
            var track = await _spotifyService.GetTrackAsync(id);
            return Ok(track);
        }

        [HttpGet("artist/top-tracks")]
        public async Task<IActionResult> ArtistTopTracks(string id)
        {
            var tracks = await _spotifyService.GetArtistTopTracksAsync(id);
            return Ok(tracks);
        }

        [HttpGet("playlist")]
        public async Task<IActionResult> PlaylistTracks(string id)
        {
            var tracks = await _spotifyService.GetPlaylistTracksAsync(id);
            return Ok(tracks);
        }

        [HttpGet("categories")]
        public async Task<IActionResult> Categories()
        {
            var categories = await _spotifyService.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}