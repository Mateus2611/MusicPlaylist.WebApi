using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MusicPlaylist.WebApi.Models.Responses
{
    public class AutoMapperResponsesProfile : Profile
    {
        public AutoMapperResponsesProfile()
        {
            CreateMap<ArtistResponse, Artist>()
                .ReverseMap();

            CreateMap<MusicResponse,Music>()
                .ReverseMap();

            CreateMap<PlaylistResponse, Playlist>()
                .ReverseMap();
        }
    }
}