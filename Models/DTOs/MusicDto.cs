using System.ComponentModel.DataAnnotations;

namespace MusicPlaylist.WebApi.Models.DTOs
{
    public class MusicDto
    {
        [Required(ErrorMessage = "Informe o nome da música.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento da música")]
        public DateTime Release
        {
            get => _release;
            set
            {
                if (value > DateTime.Now.Date)
                    throw new ArgumentException("A data de lançamento não pode ser maior que a data atual.");
                
                _release = value;
            }
        }
        
        private DateTime _release { get; set; }
        
        public int ArtistId { get; set; }
    }
}