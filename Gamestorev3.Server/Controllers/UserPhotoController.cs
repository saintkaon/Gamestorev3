using AutoMapper;
using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Gamestorev3.Server.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;

namespace Gamestorev3.Server.Controllers
{
    public class UserPhotoController : BaseController
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public UserPhotoController(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto([FromForm] IFormFile file, string email)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is Empty");
            }
            else
            {
                var memoryStream= new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var user = _context.Users.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
                UserPhotos userPhoto = new UserPhotos
                {
                    PhotoName = file.Name,
                    Photo = memoryStream.ToArray(),
                    UserId = user.Id


                };
                _context.UserPhotos.Add(userPhoto);
               await _context.SaveChangesAsync();
                return Ok(userPhoto);

            }

        }

        [HttpGet]
        public async Task<IActionResult> GetImage(string email)
        {
            var user = await _context.Users.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
            var photo = await _context.UserPhotos.FindAsync(user.UserID);
            if (photo == null)
            {
                return NotFound("no image for this user");

            }
            else
            {
                UserPhotoDTO userPhotoDTO = new UserPhotoDTO
                {
                    PhotoName = photo.PhotoName,
                    Photo = Convert.ToBase64String(photo.Photo)

                };
                return Ok(userPhotoDTO);
            }
        }



    }
}
