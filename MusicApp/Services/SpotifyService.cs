using SpotifyAPI.Web;
using SpotifyMVC.Models;

namespace SpotifyMVC.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly ISpotifyClient _spotifyClient;

        public SpotifyService(IConfiguration configuration)
        {
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator(
                    configuration["Spotify:ClientId"],
                    configuration["Spotify:ClientSecret"]
                ));

            _spotifyClient = new SpotifyClient(config);
        }

        public async Task<List<string>> SearchTracksAsync(string query)
        {
            try
            {
                var searchRequest = new SearchRequest(SearchRequest.Types.Track, query);
                var searchResponse = await _spotifyClient.Search.Item(searchRequest);

                var tracks = new List<string>();
                foreach (var track in searchResponse.Tracks.Items)
                {
                    tracks.Add(track.Name);
                }
                return tracks;
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching tracks", ex);
            }
        }

        public async Task<Track> GetTrackAsync(string trackId)
        {
            try
            {
                var track = await _spotifyClient.Tracks.Get(trackId);
                return new Track
                {
                    Name = track.Name,
                    Artist = track.Artists[0].Name,
                    Album = track.Album.Name,
                    PreviewUrl = track.PreviewUrl
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Track not found", ex);
            }
        }

        public async Task<List<string>> GetArtistTopTracksAsync(string artistId)
        {
            try
            {
                var tracks = await _spotifyClient.Artists.GetTopTracks(artistId, new ArtistsTopTracksRequest("US"));
                return tracks.Tracks.ConvertAll(track => track.Name);
            }
            catch (Exception ex)
            {
                throw new Exception("Artist not found", ex);
            }
        }

        public async Task<List<string>> GetPlaylistTracksAsync(string playlistId)
        {
            try
            {
                var tracks = await _spotifyClient.Playlists.GetItems(playlistId);
                // TODO: Fix this it might not work as expected.
                return tracks.Items.ConvertAll(item => item.Track.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Playlist not found", ex);
            }
        }

        public async Task<List<Playlist>> GetFeaturedPlaylistsAsync()
        {
            try
            {
                var featured = await _spotifyClient.Browse.GetFeaturedPlaylists();
                return featured.Playlists.Items.ConvertAll(playlist => new Playlist
                {
                    Name = playlist.Name,
                    Url = playlist.ExternalUrls["spotify"]
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting featured playlists", ex);
            }
        }

        public async Task<List<Album>> GetNewReleasesAsync()
        {
            try
            {
                var newReleases = await _spotifyClient.Browse.GetNewReleases();
                return newReleases.Albums.Items.ConvertAll(album => new Album
                {
                    Name = album.Name,
                    Url = album.ExternalUrls["spotify"]
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting new releases", ex);
            }
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _spotifyClient.Browse.GetCategories();
                return categories.Categories.Items.ConvertAll(category => category.Name);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting categories", ex);
            }
        }
    }
}