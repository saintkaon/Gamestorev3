using Gamestore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestorev3.Server.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
        public List<Games> PublishedGames { get; set; }
    }
}
