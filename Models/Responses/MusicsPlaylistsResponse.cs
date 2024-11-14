using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.Responses
{
    public class MusicsPlaylistsResponse
    {
        [JsonIgnore]
        public int MusicId { get; set; }

        public MusicDatasOnlyResponse? Musics { get; set; }
    }
}