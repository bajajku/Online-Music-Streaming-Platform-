public class Album
{
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public List<Song> Songs { get; set; }

    // Need Song class for this
    //public ICollection<Song> Songs { get; set; }
}
