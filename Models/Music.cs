using System.Text.Json.Serialization;

namespace MusicPlaylist.WebApi.Models
{
    public class Music
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime Release { get; set; }

        public int? ArtistId { get; set; }

        public required Artist Artists { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; } = [];
    }
}