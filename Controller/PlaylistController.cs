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
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistsController(IPlaylistService playlistService) => _playlistService = playlistService;

        /// <summary>
        /// Obter todas as playlists ou buscar pelo nome.
        /// </summary>
        /// <param name="name">Preencha com o nome da playlist (Opcional)</param>
        /// <returns>Coleção de playlists.</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PlaylistResponse>> Get([FromQuery(Name = "name")] string? name)
        {
            if (name is not null)
                return Ok(_playlistService.GetByName(name));

            return Ok(_playlistService.GetAll());
        }

        /// <summary>
        /// Buscar dados de uma playlist.
        /// </summary>
        /// <param name="id">Identificador da playlist.</param>
        /// <returns>Dados da playlist</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlaylistResponse> GetById([FromRoute(Name = "id")] int id)
        {
            PlaylistResponse? playlist = _playlistService.GetById(id);

            if (playlist is null)
                return NotFound();
            
            return Ok(playlist);            
        }

        /// <summary>
        /// Criar uma playlist.
        /// </summary>
        /// <remarks>
        /// name: Deve ser preenchido com nome da playlist,<br></br> 
        /// musicsIds: É uma lista que deve ser preenchida com os identificadores das músicas
        /// </remarks>
        /// <param name="playlist">Dados da playlist.</param>
        /// <returns>Objeto recém-criado.</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="400">Erro ao recuperar dados</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PlaylistResponse> Create([FromBody] PlaylistDto playlist)
        {
            try
            {
                PlaylistResponse? newPlaylist = _playlistService.Create(playlist);

                if (newPlaylist is null)
                    return NotFound();

                return CreatedAtAction(nameof(GetById), new { newPlaylist.Id }, newPlaylist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualizar dados de uma playlist.
        /// </summary>
        /// <remarks>
        /// name: Deve ser preenchido com o nome da playlist
        /// </remarks>
        /// <param name="id">Identificador da playlist.</param>
        /// <param name="playlist">Dados da playlist.</param>
        /// <returns>Objeto com dados atualizados</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MusicResponse> Update([FromRoute(Name = "id")] int id, [FromBody] PlaylistUpdateDto playlist)
        {
            PlaylistResponse? playlistUpdate = _playlistService.Update(id, playlist);

            if (playlistUpdate is null)
                return NotFound();
            
            return Ok(playlistUpdate);
        }

        /// <summary>
        /// Deletar uma playlist.
        /// </summary>
        /// <param name="id">Identificador da playlist.</param>
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
                _playlistService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Adicionar músicas na playlist.
        /// </summary>
        /// <remarks>
        /// idsMusics: É uma lista que deve ser preenchida com os identificadores das músicas
        /// </remarks>
        /// <param name="id">Identificador da playlist.</param>
        /// <param name="musics">Identificadores das músicas.</param>
        /// <returns>Playlist com músicas adicionadas</returns>
        /// <responses code="200">Sucesso</responses>
        /// <responses code="404">Não encontrado</responses>
        [HttpPut("{id}/Musics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlaylistResponse> AddMusic([FromRoute] int id, [FromBody] PlaylistMusicDto musics)
        {
            musics.IdPlaylist = id;
            var movie = _playlistService.AddMusic(musics);

            if (movie is null)
                return NotFound();

            return Ok(movie);
        }

        /// <summary>
        /// Remover músicas da playlist.
        /// </summary>
        /// <remarks>
        /// idsMusics: É uma lista que deve ser preenchida com os identificadores das músicas
        /// </remarks>
        /// <param name="id">Identificador da playlist.</param>
        /// <param name="musics">Identificadores das músicas.</param>
        /// <returns>Playlist com músicas removidas</returns>
        /// <responses code="200">Sucesso</responses>
        /// <responses code="404">Não encontrado</responses>
        [HttpDelete("{id}/Musics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlaylistResponse> RemoveMusic([FromRoute] int id, [FromBody] PlaylistMusicDto musics)
        {
            musics.IdPlaylist = id;
            var movie = _playlistService.RemoveMusic(musics);

            if (movie is null)
                return NotFound();

            return Ok(movie);
        }
    }
}