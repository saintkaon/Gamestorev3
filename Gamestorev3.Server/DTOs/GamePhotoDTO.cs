namespace Gamestorev3.Server.DTOs
{
    public class GamePhotoDTO
    {
        public byte[] Photo { get; set; }

        public string Title { get; set; }
        public bool isMain { get; set; }
        public UserDTO User { get; set; }
      
    }
}
