using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyMVC.Models;

namespace SpotifyMVC.Services
{
    public interface ISpotifyService
    {
        // TODO: Add more functions for API calls.
        Task<List<string>> SearchTracksAsync(string query);
        Task<Track> GetTrackAsync(string trackId);
        Task<List<string>> GetArtistTopTracksAsync(string artistId);
        Task<List<string>> GetPlaylistTracksAsync(string playlistId);
        Task<List<Playlist>> GetFeaturedPlaylistsAsync();
        Task<List<Album>> GetNewReleasesAsync();
        Task<List<string>> GetCategoriesAsync();
    }
}