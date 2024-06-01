using Gamestore.Models;

namespace Gamestorev3.Server.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(Users users);
    }
}
