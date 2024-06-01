using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Models
{
    public class OrderDetails
    {
        public int GameId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("GameId")]
        public Games Games { get; set; }
        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }
    }
}
