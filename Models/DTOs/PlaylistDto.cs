using System.ComponentModel.DataAnnotations;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class PlaylistDto
    {
        [Required(ErrorMessage = "Informe o nome da playlist.")]
        public required string  Name { get; set; }

        public required IEnumerable<int> MusicsIds { get; set; } = [];
    }
}