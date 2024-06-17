using Gamestore.Models;

namespace Gamestorev3.Server.DTOs
{
    public class GameDTO
    {
        public string GameName { get; set; }
        public string GameVersion { get; set; }
        public float Price { get; set; }
        public DateOnly ReleaseDate { get; set; }

       public ICollection<GamePhotos> photos { get; set; }

        public static implicit operator GameDTO(Games game)
        {
            GameDTO gameDTO = new GameDTO
            {
                GameName = game.GameName,
                GameVersion = game.GameVersion,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                photos = game.Photos
                
            };
            return gameDTO;
        }
    }
}
