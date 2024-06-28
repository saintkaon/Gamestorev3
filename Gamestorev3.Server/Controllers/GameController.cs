using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Gamestorev3.Server.Extensions;
using Gamestorev3.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace Gamestorev3.Server.Controllers
{

    public class GameController : BaseController
    {
        private readonly StoreDbContext _context;
        private readonly IGameRepository _gamerepo;

        public GameController(StoreDbContext context, IGameRepository gamerepo)
        {
            _context = context;
            _gamerepo = gamerepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetAllGames()
        {
          var games = await _gamerepo.GetAllGamesAsync();

            if(games.IsNullOrEmpty())
            { return NotFound("No games yet"); }
            else
            {
                return Ok(games);
            }
        }

        [HttpGet("{PublisherId}")]

        public async Task<ActionResult<IEnumerable<GameDTO>>> GetGamesByPublisher(int PublisherId)
        {
            var games = await _gamerepo.GamesbyPublisher(PublisherId);
            if (games.IsNullOrEmpty())
            { return NotFound("No games yet"); }
            else
            {
                return Ok(games);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<bool>> AddGames(Games games)
        {
            return await _gamerepo.AddGames(games);
        }

    }

    }

