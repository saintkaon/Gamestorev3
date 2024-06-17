using Gamestorev3.Server.DTOs;

namespace Gamestorev3.Server.Interfaces
{
    public interface IPublisherRepository
    {
        public  Task<int> FindPublisherIdAsync(int id);
        public int NumberOfGamesAsync(int PublisherId);
        public Task<List<GameDTO>> GamesByPublisher(int  PublisherId);
    }
}
