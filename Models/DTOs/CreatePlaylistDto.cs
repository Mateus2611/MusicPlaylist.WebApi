using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class CreatePlaylistDto
    {
        [Required(ErrorMessage = "Informe o nome da playlist.")]
        public required string  Name { get; set; }

        public required IEnumerable<int> MusicsIds { get; set; } = [];
    }
}