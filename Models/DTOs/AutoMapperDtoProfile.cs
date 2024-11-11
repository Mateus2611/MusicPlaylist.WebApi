using AutoMapper;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class AutoMapperDtoProfile : Profile
    {
        public AutoMapperDtoProfile()
        {
            CreateMap<ArtistDto, Artist>()
                .ReverseMap();

            CreateMap<ArtistUpdateDto, Artist>()
                .ReverseMap();

            CreateMap<MusicDto, Music>()
                .ReverseMap();

            CreateMap<MusicUpdateDto, Music>()
                .ReverseMap();

            CreateMap<PlaylistDto, Playlist>()
                .ReverseMap();
        }
    }
}