using Gamestore.Models;

namespace Gamestorev3.Server.DTOs
{
    public class GameDTO
    {
        public string GameName { get; set; }
        public string GameVersion { get; set; }
        public string MainPhoto { get; set; }
        public bool IsMain { get; set; }
        public float Price { get; set; }
        public DateOnly ReleaseDate { get; set; }

      
    }
}
