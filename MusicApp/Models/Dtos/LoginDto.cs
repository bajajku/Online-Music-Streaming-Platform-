using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.Models.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username or Email is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 chararcters allowed.")]
        [DisplayName("Username or Email")]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or min 5 chararcters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
