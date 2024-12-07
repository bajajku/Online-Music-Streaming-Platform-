using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SpotifyMVC.Models;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]


public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [MaxLength(50, ErrorMessage = "Max 50 characters allowed.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required.")]
    [MaxLength(50, ErrorMessage = "Max 50 chararcters allowed.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [MaxLength(100, ErrorMessage = "Max 100 chararcters allowed.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [MaxLength(20, ErrorMessage = "Max 20 chararcters allowed.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MaxLength(20, ErrorMessage = "Max 20 chararcters allowed.")]
    public string Password { get; set; }
    
    public bool IsPremium { get; set; }
    public ICollection<Playlist>? Playlists { get; set; }
}
