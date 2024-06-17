namespace Gamestorev3.Server.DTOs
{
    public class PhotoDTO
    {
        public byte[] Photo { get; set; }
        public string Title { get; set; }
        public UserDTO User { get; set; }
    }
}
