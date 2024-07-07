using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Models
{
    public class UserPhotos
    {
        [Key]
        public int PhotoId { get; set; }
        public string PhotoName { get; set; }
        public byte[] Photo { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        

    }
}
