using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace Gamestore.Models
{
    public class GamePhotos
    {
        [Key]
        public int PhotoId { get; set; }
        public byte[] Photo { get; set; }
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Games Games { get; set; }

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
