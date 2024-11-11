using System.Text.Json.Serialization;

namespace MusicPlaylist.WebApi.Models.Responses
{
    public class ArtistResponse
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Bio { get; set; }
        
        public virtual IEnumerable<MusicDatasOnlyResponse> Musics { get; set; } = [];
    }
}