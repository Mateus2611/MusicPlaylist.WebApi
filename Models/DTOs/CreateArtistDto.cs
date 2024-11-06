using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class CreateArtistDto
    {
        [Required(ErrorMessage = "Informe o nome do filme.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Informe a biografia do artista.")]
        public required string Bio { get; set; }
    }
}