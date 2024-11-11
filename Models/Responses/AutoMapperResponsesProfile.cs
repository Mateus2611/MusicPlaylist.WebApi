using AutoMapper;

namespace MusicPlaylist.WebApi.Models.Responses
{
    public class AutoMapperResponsesProfile : Profile
    {
        public AutoMapperResponsesProfile()
        {
            CreateMap<ArtistResponse, Artist>()
                .ReverseMap();

            CreateMap<ArtistOnlyDatasResponse, Artist>()
                .ReverseMap();

            CreateMap<MusicResponse,Music>()
                .ReverseMap();

            CreateMap<MusicDatasOnlyResponse, Music>()
                .ReverseMap();

            CreateMap<PlaylistResponse, Playlist>()
                .ReverseMap();
        }
    }
}