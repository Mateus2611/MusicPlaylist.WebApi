using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.Responses
{
    public class ArtistResponse
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Bio { get; set; }

        public required IEnumerable<Music> Musics { get; set; } = [];
    }
}