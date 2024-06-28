using Gamestore.Models;
using Gamestorev3.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Gamestorev3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugController : BaseController
    {
        private readonly StoreDbContext _context;

        public BugController(StoreDbContext context)
        {
            this._context = context;
        }
        [HttpGet("not-found")]
        public ActionResult <Users> GetNotFound()
        {
            var user = _context.Users.Find(-1);
            if (user == null) return NotFound();
            else return user;
        }
        [HttpGet("auth")]
        public ActionResult<Users> NotAuthorized()
        {
            return NotAuthorized();
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var user = _context.Users.Find(-1);
            var user2 = user.ToString();
            return user2;
        }

        [HttpGet("bad-request")]
        public ActionResult <string> BadRequestError() 
        {
            return BadRequest("Bad Request");
        }
    }
}
