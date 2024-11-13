namespace MusicPlaylist.WebApi.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }

        public virtual ICollection<MusicsPlaylists> MusicPlaylists { get; set; } = [];
    }
}