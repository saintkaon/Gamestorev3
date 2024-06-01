using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace Gamestorev3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {

        private readonly StoreDbContext _context;

        public AccountController(StoreDbContext context)
        {
            _context = context;

        }


        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(RegisterDTO rdo)
        {
            if (await IsExist(rdo.Email)) return BadRequest("Username Exists");
            
                using var hash = new HMACSHA256();
                var user = new Users
                {
                    EmailAddress = rdo.Email,
                    PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(rdo.password)),
                    PasswordSalt = hash.Key,
                    Nickname = rdo.nickname

                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;

            
          
        }
        public async Task<bool> IsExist(string email)
        {
            return await _context.Users.AnyAsync(x => x.EmailAddress == email);

        }
        public async Task<ActionResult<Users>> Login(LoginDTO ldo)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=> x.EmailAddress == ldo.EmailAddress);
            if (user == null) return NotFound("Not a user");
            var hash = new HMACSHA512(user.PasswordSalt);
            var hash2= hash.ComputeHash(Encoding.UTF8.GetBytes(ldo.password));
            for(int i = 0; i < hash2.Length; i++)
            {
                if (hash2[i] != user.PasswordHash[i]) return NotFound("Incorrect Username or Password");
            }
            return user;

        }
    }
}
