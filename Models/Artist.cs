using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models
{
    public class Artist
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }

        public required string Bio { get; set; }

        public required ICollection<Music> Musics { get; set; } = [];
    }
}