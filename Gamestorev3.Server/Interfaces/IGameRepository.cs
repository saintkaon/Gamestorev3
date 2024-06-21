using Gamestore.Models;
using Gamestorev3.Server.DTOs;

namespace Gamestorev3.Server.Interfaces
{
    public interface IGameRepository
    {
        public Task<IEnumerable<GameDTO>> GetAllGamesAsync();
        public Task<IEnumerable<GameDTO>> GamesbyPublisher(int PublisherId);
        public Task<bool> AddGames(Games game);
    }
}
