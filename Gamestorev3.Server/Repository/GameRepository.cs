using AutoMapper;
using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Gamestorev3.Server.Interfaces;
using Gamestorev3.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Identity.AuthenticationEventsFlows.Item.GraphExternalUsersSelfServiceSignUpEventsFlow.OnAuthenticationMethodLoadStart.GraphOnAuthenticationMethodLoadStartExternalUsersSelfServiceSignUp;
using System.Collections.Generic;

namespace Gamestorev3.Server.Repository
{
    public class GameRepository : IGameRepository
    {
        StoreDbContext _context;
        IMapper _mapper;
        public async Task<bool> AddGames(Games game)
        {
            _context.Games.Add(game);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            else return false;
            

        }

        public async Task<IEnumerable<GameDTO>> GamesbyPublisher(int PublisherId)
        {
           List<Games> games1 = await _context.Games.Where(x => x.PublisherId == PublisherId).ToListAsync();
            List<GameDTO> games2 = _mapper.Map<List<GameDTO>>(games1);
            return games2;
          
            
        }

        public async Task<IEnumerable<GameDTO>> GetAllGamesAsync()
        {
            List<Games> games1 = await _context.Games.ToListAsync();
            List<GameDTO> games2 = _mapper.Map<List<GameDTO>>(games1);
            return games2;

        }
    }
}
