using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public List<OrderDetails> Details { get; set; }
    }
}
