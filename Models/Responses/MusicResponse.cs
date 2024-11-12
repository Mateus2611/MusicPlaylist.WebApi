namespace MusicPlaylist.WebApi.Models.Responses
{
    public class MusicResponse
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime Release { get; set; }

        public required virtual ArtistOnlyDatasResponse Artists { get; set; }
    }
}