using System.ComponentModel.DataAnnotations;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class ArtistDto
    {
        [Required(ErrorMessage = "Informe o nome do filme.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Informe a biografia do artista.")]
        public required string Bio { get; set; }
    }
}