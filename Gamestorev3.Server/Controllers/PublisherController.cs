using AutoMapper;
using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Gamestorev3.Server.Extensions;
using Gamestorev3.Server.Interfaces;
using Gamestorev3.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Gamestorev3.Server.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PublisherController : ApiController
    {
        private readonly StoreDbContext _context;
        private readonly ITokenService _token;
        private readonly IPublisherRepository _publishrepo;
        private readonly IMapper _map;

        public PublisherController(StoreDbContext context, ITokenService token, IPublisherRepository publishrepo, IMapper map)
        {
            this._context = context;
            this._token = token;
            this._publishrepo = publishrepo;
            this._map = map;
        }

        [HttpPost("register")]

        public async Task<ActionResult<PublisherDTO>> BecomeAPublisher(int UserId)
        {
            if (_context.Publisher.Any(x => x.UserId == UserId))
            {
                return Unauthorized("Already exists");

            }
            else
            {
                var pub = new Publisher { UserId = UserId };
                _context.Publisher.Add(pub);
                await _context.SaveChangesAsync();

                var user1 = await _context.Users.FindAsync(UserId);
                int pubid = await _publishrepo.FindPublisherIdAsync(UserId);


                PublisherDTO pubz = new PublisherDTO
                {
                    User = new UserDTO
                    {
                        EmailAddress = user1.EmailAddress,
                        nickname = user1.Nickname,
                        Token = _token.CreateToken(user1)
                    }
                    ,


                    Games = await _publishrepo.GamesByPublisher(pubid)


                };
                return pubz;
            }





        }
    }
}

