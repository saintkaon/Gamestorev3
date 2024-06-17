using Gamestore.Models;

namespace Gamestorev3.Server.Interfaces
{
    public interface IUserRepository
    {
        void update(Users user);
        public Task<IEnumerable<Users>> GetUsers();
        public Task<Users> GetUserbyIdAsync(int id);
        public Task<Users> GetUserbyEmailAsync(string email);
        public Task<bool> SaveAllAsync();
    }
}
