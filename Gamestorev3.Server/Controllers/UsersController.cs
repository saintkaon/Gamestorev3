using Gamestore.Models;
using Gamestorev3.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gamestorev3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: Controller
    {
        private readonly StoreDbContext _context;
        private readonly IUserRepository _userrepo;

        public UsersController(StoreDbContext context, IUserRepository userrepo)
        {
            _context = context;
            _userrepo = userrepo;
        }

        [HttpGet]
        public async Task<ActionResult <IEnumerable<Users>>> GetUsers()
        {
            return Ok(await _userrepo.GetUsers());
           
        }
        [HttpGet("{UserId}")]

        public async Task<ActionResult<Users>> GetUserById(int id)
        {
          
            return await _userrepo.GetUserbyIdAsync(id);
        }
        [HttpGet("{EmailAddress}")]
        public async Task<ActionResult<Users>> GetUserByEmail(string email)
        {
            return await _userrepo.GetUserbyEmailAsync(email);
        }
    }
}
