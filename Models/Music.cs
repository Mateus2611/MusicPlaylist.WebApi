using System.Text.Json.Serialization;

namespace MusicPlaylist.WebApi.Models
{
    public class Music
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime Release { get; set; }

        public int ArtistId { get; set; }

        public Artist? Artists { get; set; }

        [JsonIgnore]
        public virtual ICollection<MusicsPlaylists> MusicPlaylists { get; set; } = [];
    }
}