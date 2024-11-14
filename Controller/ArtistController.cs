using Microsoft.AspNetCore.Mvc;
using MusicPlaylist.WebApi.Models.DTOs;
using MusicPlaylist.WebApi.Models.Responses;
using MusicPlaylist.WebApi.Services.Interfaces;

namespace MusicPlaylist.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService) => _artistService = artistService;

        [HttpGet]
        public ActionResult<IEnumerable<ArtistResponse>> Get([FromQuery(Name = "name")] string? name)
        {
            if (name is not null)
                return Ok(_artistService.GetByName(name));

            return Ok(_artistService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ArtistResponse> GetById([FromRoute(Name = "id")] int id)
        {
            try
            {
                ArtistResponse? artist = _artistService.GetById(id);

                if (artist is null)
                    return NotFound();

                return Ok(artist);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ArtistResponse> Create([FromBody] ArtistDto artist)
        {
            try
            {
                ArtistResponse? newArtist = _artistService.Create(artist);

                if (newArtist is null)
                    return NotFound();

                return CreatedAtAction(nameof(GetById), new { newArtist.Id }, newArtist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ArtistResponse> Update([FromRoute(Name = "id")] int id, [FromBody] ArtistUpdateDto artist)
        {
            try
            {
                ArtistResponse? artistUpdate = _artistService.Update(id, artist);

                if (artistUpdate is null)
                    return NotFound();

                return Ok(artistUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute(Name = "id")] int id)
        {
            try
            {
                _artistService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}