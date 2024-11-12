using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class PlaylistMusicDto
    {
        [JsonIgnore]
        public int IdPlaylist { get; set; }

        public IEnumerable<int> IdsMusics { get; set; } = [];
    }
}