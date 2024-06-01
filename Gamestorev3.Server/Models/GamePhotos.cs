using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Gamestore.Models
{
    public class GamePhotos
    {
        [Key]
        public int PhotoId { get; set; }
        public string PhotoPath { get; set; }
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Games Games { get; set; }

    }
}
