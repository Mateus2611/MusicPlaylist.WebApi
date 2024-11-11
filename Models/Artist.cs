namespace MusicPlaylist.WebApi.Models
{
    public class Artist
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }

        public required string Bio { get; set; }

        public ICollection<Music> Musics { get; set; } = [];
    }
}