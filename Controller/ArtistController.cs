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

        /// <summary>
        /// Obter todos os artistas ou buscar pelo nome.
        /// </summary>
        /// <param name="name">Preencha com o nome do artista (Opcional).</param>
        /// <returns>Coleção de artistas.</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ArtistResponse>> Get([FromQuery(Name = "name")] string? name)
        {
            if (name is not null)
                return Ok(_artistService.GetByName(name));

            return Ok(_artistService.GetAll());
        }

        /// <summary>
        /// Obter dados de um artista.
        /// </summary>
        /// <param name="id">Identificador do artista.</param>
        /// <returns>Dados do artista</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Criar um artista.
        /// </summary>
        /// <remarks>
        ///     "name": (Este campo deve ser preenchido com o nome do artista desejado.),
        ///     "bio": (Este campo deve ser preenchido com a biografia do artista).
        /// </remarks>
        /// <param name="artist">Dados do artista.</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]	
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

        /// <summary>
        /// Atualizar dados do artista.
        /// </summary>
        /// <remarks>
        ///     "name": (Este campo deve ser preenchido com o nome do artista desejado.),
        ///     "bio": (Este campo deve ser preenchido com a biografia do artista).
        /// </remarks>
        /// <param name="id">Identificador do artista.</param>
        /// <param name="artist">Dados do artista.</param>
        /// <returns>Objeto com dados atualizados.</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="400">Erro ao buscar dados</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Deletar um artista
        /// </summary>
        /// <param name="id">Identificador do artista.</param>
        /// <returns>Sem retorno</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não encontrado</response>
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