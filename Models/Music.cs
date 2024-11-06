using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models
{
    public class Music
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateOnly Release { get; set; }

        public required Artist Artists { get; set; }

        public required ICollection<Playlist> Playlists { get; set; } = [];
    }
}