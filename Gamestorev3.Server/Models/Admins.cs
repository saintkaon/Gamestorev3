using Gamestore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestorev3.Server.Models
{
    public class Admins
    {
        [Key]
        public int AdminId { get; set; } 
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }
    }
}
