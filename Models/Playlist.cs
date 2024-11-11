namespace MusicPlaylist.WebApi.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }

        public ICollection<Music> Musics { get; set; } = [];
    }
}