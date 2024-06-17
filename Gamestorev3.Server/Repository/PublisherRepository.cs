using AutoMapper;
using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Gamestorev3.Server.Interfaces;
using Gamestorev3.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamestorev3.Server.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly StoreDbContext _context;
        private readonly ITokenService _token;
        private readonly IMapper _map;

        public PublisherRepository(StoreDbContext context, ITokenService token, IMapper map)
        {
            _context = context;
            _token = token;
            _map = map;
        }
        public async Task<int> FindPublisherIdAsync(int UserId)
        {
            if (_context.Users.Any(x => x.UserID == UserId))
            {
                var user1 = await _context.Publisher.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
                return user1.PublisherId;
            }
            else { return 0; }

            
           

            
        }

       
        public  int NumberOfGamesAsync(int PublisherId)
        {
            List<Games> numberofGames = _context.Games.Where(x => x.PublisherId == PublisherId).ToList();
            return numberofGames.Count;
        }
        public async Task<List<GameDTO>> GamesByPublisher(int PublisherId)
        {
            List<Games> games = await _context.Games.Where(x=>x.PublisherId == PublisherId).ToListAsync();

            List<GameDTO> result = _map.Map<List<GameDTO>>(games);
            return await Task.FromResult(result);
        }

    }
}
