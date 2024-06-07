using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Gamestorev3.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;


namespace Gamestorev3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {

        private readonly StoreDbContext _context;
        private readonly ITokenService _token;
        

        public AccountController(StoreDbContext context, ITokenService tokenService)
        {
            _token= tokenService;
            _context = context;

        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO rdo)
        {
            if (await IsExist(rdo.Email)) return BadRequest("Username Exists");
            
                using var hash = new HMACSHA256();
                var user = new Users
                {
                    EmailAddress = rdo.Email,
                    PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(rdo.Password)),
                    PasswordSalt = hash.Key,
                    Nickname = rdo.nickname

                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();


            return new UserDTO
            {
                EmailAddress = rdo.Email,
                NickName = rdo.nickname,
                Token = _token.CreateToken(user)
            };

           

        }
        async Task<bool> IsExist(string email)
        {
            return await _context.Users.AnyAsync(x => x.EmailAddress == email);

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO ldo)
        {
            
            var user = await _context.Users.SingleOrDefaultAsync(x=> x.EmailAddress == ldo.EmailAddress);
            if (user == null) return NotFound("Not a user bitch");
            using var hash = new HMACSHA256(user.PasswordSalt);
            var hash2= hash.ComputeHash(Encoding.UTF8.GetBytes(ldo.password));
            for(int i = 0; i < hash2.Length ; i++)
            {
                if (hash2[i] != user.PasswordHash[i]) return Unauthorized("Wrong E-mail address or Password");
            }
            var user1=_context.Users.First(x=>x.EmailAddress == ldo.EmailAddress);
           
            return new UserDTO
            {
                

                EmailAddress = ldo.EmailAddress,
                NickName=user1.Nickname,
                Token = _token.CreateToken(user)
            };
        }
    }
}
