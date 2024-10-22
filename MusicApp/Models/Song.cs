public class Song
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public Album Album { get; set; }
    public TimeSpan Duration { get; set; }
    public string FileLocation { get; set; }
}
