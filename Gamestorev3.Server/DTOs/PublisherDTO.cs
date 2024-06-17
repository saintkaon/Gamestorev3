using Gamestore.Models;

namespace Gamestorev3.Server.DTOs
{
    public class PublisherDTO
    {
        public UserDTO User { get; set; }
        public List<GameDTO> Games { get; set; }
    }
}
