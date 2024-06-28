using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Models
{
    public class UserPhotos
    {
        [Key]
        public int PhotoId { get; set; }
        public byte[] PhotoPath { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public static string GetPhoto(byte[] data)
        {
            string finalresult;
            if (data == null)
            {
                return "No Image";

            }
            else
            {
                return finalresult = Convert.ToBase64String(data);

            }

        }

    }
}
