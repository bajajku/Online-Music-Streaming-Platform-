using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyMVC.Models;

namespace SpotifyMVC.Services
{
    public interface ISpotifyService
    {
        Task<List<Track>> SearchTracksAsync(string query);
        Task<Track> GetTrackAsync(string trackId);
        Task<List<Track>> GetArtistTopTracksAsync(string artistId);
        Task<PlaylistTracks> GetPlaylistTracksAsync(string playlistId);
        Task<List<Category>> GetCategoriesAsync();
        Task<List<Album>> GetNewReleasesAsync();
    }
}