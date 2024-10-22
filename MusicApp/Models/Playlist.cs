public class Playlist
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public User User { get; set; }
    public ICollection<Song>? Songs { get; set; }
}
