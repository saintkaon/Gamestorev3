using System.ComponentModel.DataAnnotations;

namespace Gamestorev3.Server.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string nickname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }
        
    }
}
