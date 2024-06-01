using System.ComponentModel.DataAnnotations;

namespace Gamestore.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string EmailAddress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Nickname { get; set; }
        
        public List<UserPhotos> Photos { get; set; }
        public List<Orders> Orders { get; set; }
       

        

    }
}
