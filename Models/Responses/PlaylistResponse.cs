namespace MusicPlaylist.WebApi.Models.Responses
{
    public class PlaylistResponse
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public virtual required IEnumerable<Music> Musics { get; set; } = [];
    }
}