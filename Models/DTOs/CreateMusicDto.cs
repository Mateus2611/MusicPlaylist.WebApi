using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class CreateMusicDto
    {
        [Required(ErrorMessage = "Informe o nome da música.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento da música")]
        public DateOnly Release
        {
            get => _release;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now.Date))
                    throw new ArgumentException("A data de lançamento não pode ser maior que a data atual.");
                
                _release = value;
            }
        }
        
        private DateOnly _release { get; set; }
    }
}