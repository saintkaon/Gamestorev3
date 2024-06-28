using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Graph;
using System.Runtime.CompilerServices;

namespace Gamestorev3.Server.DTOs
{
    public class UserPhotoDTO
    {
        public byte[] ImageData { get; set; }
        public string MainPhoto { get; set; }
        public string Title { get; set; }
        public bool isMain { get; set; }
        public UserDTO User { get; set; }
        
    }
}
