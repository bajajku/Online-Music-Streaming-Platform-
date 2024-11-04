// Models/SpotifyModels.cs
using System.Collections.Generic;

namespace SpotifyMVC.Models
{
    public class Track
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string PreviewUrl { get; set; }
    }

    public class Playlist
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Album
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}