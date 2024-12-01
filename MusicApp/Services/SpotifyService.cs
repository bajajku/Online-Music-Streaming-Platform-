using SpotifyAPI.Web;
using SpotifyMVC.Models;
using Category = SpotifyMVC.Models.Category;

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

        public async Task<List<Track>> SearchTracksAsync(string query)
        {
            try
            {
                var searchRequest = new SearchRequest(SearchRequest.Types.Track, query);
                var searchResponse = await _spotifyClient.Search.Item(searchRequest);
                Console.WriteLine($"Search: {query}, Total: {searchResponse.Tracks}");

                return searchResponse.Tracks.Items.Select(track => MapToTrack(track)).ToList();
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
                return MapToTrack(track);
            }
            catch (Exception ex)
            {
                throw new Exception("Track not found", ex);
            }
        }

        public async Task<List<Track>> GetArtistTopTracksAsync(string artistId)
        {
            try
            {
                var tracks = await _spotifyClient.Artists.GetTopTracks(artistId, new ArtistsTopTracksRequest("US"));
                return tracks.Tracks.Select(track => MapToTrack(track)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Artist not found", ex);
            }
        }

        public async Task<PlaylistTracks> GetPlaylistTracksAsync(string playlistId)
        {
            try
            {
                var tracks = await _spotifyClient.Playlists.GetItems(playlistId);
                return new PlaylistTracks
                {
                    Total = (int)tracks.Total,
                    Items = tracks.Items.Select(item => new PlaylistTrack
                    {
                        Track = MapToTrack((FullTrack)item.Track),
                        AddedAt = (DateTime)item.AddedAt
                    }).ToList()
                };
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
                return featured.Playlists.Items.Select(playlist => new Playlist
                {
                    Id = playlist.Id,
                    Name = playlist.Name,
                    Description = playlist.Description,
                    Images = playlist.Images.Select(img => new SpotifyImage
                    {
                        Url = img.Url,
                        Height = img.Height,
                        Width = img.Width
                    }).ToList(),
                    ExternalUrls = new ExternalUrls { Spotify = playlist.ExternalUrls["spotify"] },
                    Owner = new PlaylistOwner
                    {
                        Id = playlist.Owner.Id,
                        DisplayName = playlist.Owner.DisplayName,
                        ExternalUrls = new ExternalUrls { Spotify = playlist.Owner.ExternalUrls["spotify"] }
                    },
                    Public = playlist.Public ?? false
                }).ToList();
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
                    ExternalUrls = new ExternalUrls { Spotify = album.ExternalUrls["spotify"] }
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting new releases", ex);
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _spotifyClient.Browse.GetCategories();
                return categories.Categories.Items.ConvertAll(category => new Category
                {
                    Name = category.Name,
                    Icons = category.Icons.Select(img => new SpotifyImage
                    {
                        Url = img.Url,
                        Height = img.Height,
                        Width = img.Width
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting categories", ex);
            }
        }

        private Track MapToTrack(FullTrack spotifyTrack)
        {
            Console.WriteLine($"Track: {spotifyTrack.Name}, PreviewUrl: {spotifyTrack.PreviewUrl}");
            return new Track
            {
                Id = spotifyTrack.Id,
                Name = spotifyTrack.Name,
                Artists = spotifyTrack.Artists.Select(artist => new Artist
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    ExternalUrls = new ExternalUrls { Spotify = artist.ExternalUrls["spotify"] }
                }).ToList(),
                Album = new Album
                {
                    Id = spotifyTrack.Album.Id,
                    Name = spotifyTrack.Album.Name,
                    Images = spotifyTrack.Album.Images.Select(img => new SpotifyImage
                    {
                        Url = img.Url,
                        Height = img.Height,
                        Width = img.Width
                    }).ToList(),
                    ReleaseDate = spotifyTrack.Album.ReleaseDate,
                    ReleaseDatePrecision = spotifyTrack.Album.ReleaseDatePrecision,
                    ExternalUrls = new ExternalUrls { Spotify = spotifyTrack.Album.ExternalUrls["spotify"] }
                },
                DurationMs = spotifyTrack.DurationMs,
                ExternalUrls = new ExternalUrls { Spotify = spotifyTrack.ExternalUrls["spotify"] },
                PreviewUrl = spotifyTrack.PreviewUrl,
                IsPlayable = spotifyTrack.IsPlayable
            };
        }
    }

}