using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class ArtistUpdateDto
    {
        public string? Name { get; set; }

        public string? Bio { get; set; }
    }
}