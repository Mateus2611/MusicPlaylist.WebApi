using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicPlaylist.WebApi.Models.DTOs;
using MusicPlaylist.WebApi.Models.Responses;
using MusicPlaylist.WebApi.Services.Interfaces;

namespace MusicPlaylist.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicsController(IMusicService musicService) => _musicService = musicService;

        /// <summary>
        /// Obter todas as músicas ou buscar pelo nome.
        /// </summary>
        /// <param name="name">Preencha com o nome da música (Opcional).</param>
        /// <returns>Coleção de músicas.</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MusicResponse>> Get([FromQuery(Name = "name")] string? name)
        {
            if (name is not null)
                return Ok(_musicService.GetByName(name));

            return Ok(_musicService.GetAll());
        }

        /// <summary>
        /// Obter dados de uma música.
        /// </summary>
        /// <param name="id">Identificador da música.</param>
        /// <returns>Dados da música</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MusicResponse> GetById([FromRoute(Name = "id")] int id)
        {
            MusicResponse? music = _musicService.GetById(id);

            if (music is null)
                return NotFound();
            
            return Ok(music);            
        }

        /// <summary>
        /// Criar uma música.
        /// </summary>
        /// <remarks>
        ///     "name": (Deve ser preenchido com o nome da música), 
        ///     "release": (Deve ser preenchido com a data de lançamento da música no formato yyyy-MM-dd), 
        ///     "artistId": (Deve ser preenchido com o identificador do artista responsável pela música)
        /// </remarks>
        /// <param name="music">Dados da música.</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MusicResponse> Create([FromBody] MusicDto music)
        {
            try
            {
                MusicResponse? newMusic = _musicService.Create(music);

                if (newMusic is null)
                    return NotFound();

                return CreatedAtAction(nameof(GetById), new { newMusic.Id }, newMusic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualizar dados da música.
        /// </summary>
        /// <remarks>
        ///     "name": (Deve ser preenchido com o nome da música), 
        ///     "release": (Deve ser preenchido com a data de lançamento da música no formato yyyy-MM-dd), 
        ///     "artistId": (Deve ser preenchido com o identificador do artista responsável pela música)
        /// </remarks>
        /// <param name="id">Identificador da música.</param>
        /// <param name="music">Dados da música.</param>
        /// <returns>Objeto com dados atualizados.</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MusicResponse> Update([FromRoute(Name = "id")] int id, [FromBody] MusicUpdateDto music)
        {
            MusicResponse? musicUpdate = _musicService.Update(id, music);

            if (musicUpdate is null)
                return NotFound();
            
            return Ok(musicUpdate);
        }

        /// <summary>
        /// Deletar uma música.
        /// </summary>
        /// <param name="id">Identificador da música.</param>
        /// <returns>Sem retorno</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete([FromRoute(Name = "id")] int id)
        {
            try
            {
                _musicService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}