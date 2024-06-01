using System.ComponentModel.DataAnnotations;

namespace Gamestorev3.Server.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string nickname { get; set; }
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
        [Compare("Password")]
        [Required]
        public string confirmpassword { get; set; }
        
    }
}
