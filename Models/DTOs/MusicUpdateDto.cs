using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class MusicUpdateDto
    {
        public required string Name { get; set; }

        public DateTime Release { get; set; }

        public int ArtistId { get; set; }
    }
}