using AutoMapper;
using Gamestore.Models;
using Gamestorev3.Server.DTOs;
using Gamestorev3.Server.Models;

namespace Gamestorev3.Server._Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UserDTO>();
            CreateMap<Games, GameDTO>();
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<GamePhotos, GamePhotoDTO>();
            CreateMap<UserPhotos, UserPhotoDTO>();
            CreateMap<RegisterDTO, Users>();

        }
    }
}
