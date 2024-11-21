// Models/SpotifyModels.cs
using System;
using System.Collections.Generic;

namespace SpotifyMVC.Models
{
    public class SpotifyImage
    {
        public string Url { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
    }

    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<SpotifyImage> Images { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
    }

    public class Track
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Artist> Artists { get; set; }
        public Album Album { get; set; }
        public int DurationMs { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string PreviewUrl { get; set; }
        public bool IsPlayable { get; set; }
    }

    public class Album
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Artist> Artists { get; set; }
        public List<SpotifyImage> Images { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDatePrecision { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
    }

    public class Playlist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SpotifyImage> Images { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public PlaylistOwner Owner { get; set; }
        public bool Public { get; set; }
        public PlaylistTracks Tracks { get; set; }
    }

    public class PlaylistOwner
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
    }

    public class PlaylistTracks
    {
        public int Total { get; set; }
        public List<PlaylistTrack> Items { get; set; }
    }

    public class PlaylistTrack
    {
        public Track Track { get; set; }
        public DateTime AddedAt { get; set; }
    }

    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public class PagingObject<T>
    {
        public string Href { get; set; }
        public List<T> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public string Previous { get; set; }
        public int Total { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<SpotifyImage> Icons { get; set; }
    }
}