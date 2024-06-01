using Gamestorev3.Server.Models;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Models
{
    public class Games
    {
        [Key]
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameVersion { get; set; }

        public float Price { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher PublishedBy { get; set; }


        public List<GamePhotos> Photos { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }



    }
}
