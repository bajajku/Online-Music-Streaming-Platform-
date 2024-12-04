namespace SpotifyMVC.Models.Responses
{
    public class SearchResponse
    {
        public PagingObject<Track> Tracks { get; set; }
        public PagingObject<Artist> Artists { get; set; }
        public PagingObject<Album> Albums { get; set; }
        public PagingObject<Playlist> Playlists { get; set; }
    }

    public class FeaturedPlaylistsResponse
    {
        public string Message { get; set; }
        public PagingObject<Playlist> Playlists { get; set; }
    }

    public class NewReleasesResponse
    {
        public PagingObject<Album> Albums { get; set; }
    }
} 