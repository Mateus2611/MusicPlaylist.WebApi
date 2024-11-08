using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.Responses
{
    public class MusicResponse
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateOnly Release { get; set; }

        public required Artist Artist { get; set; }

        public required IEnumerable<Playlist> Playlists { get; set; } = [];
    }
}