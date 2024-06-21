using Microsoft.AspNetCore.Mvc;

namespace Gamestorev3.Server.Extensions
{
    public class ApiController:Controller
    {
        [ApiController]
        [Route("api/[controller]")]
    }
}
