using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }

        public ICollection<Music> Musics { get; set; } = [];
    }
}