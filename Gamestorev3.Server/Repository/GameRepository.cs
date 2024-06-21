using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Gamestorev3.Server.Interfaces;
using Gamestorev3.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Gamestorev3.Server.Repository
{
    public class GameRepository : IGameRepository
    {
        StoreDbContext _context;
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
            List<GameDTO> games2 = new List<GameDTO>();
            if (games1.Count > 0)
            {

                for (int i = 0; i < games1.Count; i++)
                {
                    games2[i] = games1[i];

                }
                return games2;

            }
            else
            {
                return games2.DefaultIfEmpty();
            }
          
            
        }

        public async Task<IEnumerable<GameDTO>> GetAllGamesAsync()
        {
            List<Games> games1 = await _context.Games.ToListAsync();
            List<GameDTO> games2 = new List<GameDTO>();
         

                for (int i = 0; i < games1.Count; i++)
                {
                    games2[i] = games1[i];

                }
            return games2;

        }
    }
}
