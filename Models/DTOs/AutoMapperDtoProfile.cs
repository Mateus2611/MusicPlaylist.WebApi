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
            CreateMap<ArtistDto, Artist>()
                .ReverseMap();

            CreateMap<MusicDto, Music>()
                .ReverseMap();

            CreateMap<PlaylistDto, Playlist>()
                .ReverseMap();
        }
    }
}