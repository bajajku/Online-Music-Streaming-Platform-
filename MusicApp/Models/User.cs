public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool IsPremium { get; set; }
    public ICollection<Playlist>? Playlists { get; set; }
}
