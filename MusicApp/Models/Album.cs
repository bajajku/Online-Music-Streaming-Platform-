public class Album
{
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public DateTime ReleaseDate { get; set; }

    // Need Song class for this
    //public ICollection<Song> Songs { get; set; }
}
