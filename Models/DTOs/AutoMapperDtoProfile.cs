using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class AutoMapperDtoProfile : Profile
    {
        public AutoMapperDtoProfile()
        {
            CreateMap<CreateArtistDto, Artist>()
                .ReverseMap();

            CreateMap<CreateMusicDto, Music>()
                .ReverseMap();

            CreateMap<CreatePlaylistDto, Playlist>()
                .ReverseMap();
        }
    }
}