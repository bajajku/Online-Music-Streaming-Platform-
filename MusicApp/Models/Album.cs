public class Album
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<Song> Songs { get; set; }
}
