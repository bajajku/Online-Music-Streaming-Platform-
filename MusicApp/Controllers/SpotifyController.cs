using Microsoft.AspNetCore.Mvc;
using SpotifyMVC.Models;
using SpotifyMVC.Services;
using System.Threading.Tasks;


namespace SpotifyMVC.Controllers
{

    /// <summary>
    /// Controller for Spotify API endpoints
    /// </summary>
    [ApiController]
    [Route("api")]
    public class SpotifyController : Controller
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }
        /// <summary>
        /// Search for tracks, artists, albums, or playlists
        /// </summary>
        /// <param name="query"></param>
        /// <response code="200">Returns track based on query</response>
        /// <response code="500">If the server encountered an error</response>
        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return Ok(new List<Track>());

            var tracks = await _spotifyService.SearchTracksAsync(query);
            return Ok(tracks);
        }
        /// <summary>
        /// Get a track by ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns track object based on trackID</response>
        /// <response code="500">If the server encountered an error</response>
        [HttpGet("track")]
        public async Task<IActionResult> Track(string id)
        {
            var track = await _spotifyService.GetTrackAsync(id);
            return Ok(track);
        }
        /// <summary>
        /// Get artist's top tracks by ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns the artists top tracks based on artistID</response>
        /// <response code="500">If the server encountered an error</response>
        [HttpGet("artist/top-tracks")]
        public async Task<IActionResult> ArtistTopTracks(string id)
        {
            var tracks = await _spotifyService.GetArtistTopTracksAsync(id);
            return Ok(tracks);
        }

        /// <summary>
        /// Get playlsit from ID
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Returns the playlist based on unique playlistID</response>
        /// <response code="500">If the server encountered an error</response>
        [HttpGet("playlist")]
        public async Task<IActionResult> PlaylistTracks(string id)
        {
            var tracks = await _spotifyService.GetPlaylistTracksAsync(id);
            return Ok(tracks);
        }
        /// <summary>
        /// Get categories from Spotify API
        /// </summary>
        /// <response code="200">Returns the list of categories</response>

        [HttpGet("categories")]
        public async Task<IActionResult> Categories()
        {
            var categories = await _spotifyService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("new-releases")]
        public async Task<IActionResult> NewReleases()
        {
            var albums = await _spotifyService.GetNewReleasesAsync();
            return Ok(albums);
        }
    }
}