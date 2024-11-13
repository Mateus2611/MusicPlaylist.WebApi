using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models
{
    public class MusicsPlaylists
    {
        public int MusicId { get; set; }

        public Music? Musics { get; set; }

        public int PlaylistId { get; set; }

        public Playlist? Playlists { get; set; }
    }
}