using Gamestore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gamestorev3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {

        public GameController(StoreDbContext context)
        {
            
        }

    }
}
