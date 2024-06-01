using Gamestore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamestorev3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: Controller
    {
        private readonly StoreDbContext _context;

        public UsersController(StoreDbContext context)
        {
            _context = context;
                
        }

        [HttpGet]
        public async Task<ActionResult <IEnumerable<Users>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        [HttpGet("{UserId}")]

        public async Task<ActionResult<Users>> GetUser(int id)
        {
          
            return await _context.Users.FindAsync(id);
        }
    }
}
