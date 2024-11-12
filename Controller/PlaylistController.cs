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

        [HttpGet]
        public ActionResult<IEnumerable<PlaylistResponse>> Get([FromQuery(Name = "name")] string? name)
        {
            if (name is not null)
                return Ok(_playlistService.GetByName(name));

            return Ok(_playlistService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<PlaylistResponse> GetById([FromRoute(Name = "id")] int id)
        {
            PlaylistResponse? playlist = _playlistService.GetById(id);

            if (playlist is null)
                return NotFound();
            
            return Ok(playlist);            
        }

        [HttpPost]
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

        [HttpPut("{id}")]
        public ActionResult<MusicResponse> Update([FromRoute(Name = "id")] int id, [FromBody] PlaylistUpdateDto playlist)
        {
            PlaylistResponse? playlistUpdate = _playlistService.Update(id, playlist);

            if (playlistUpdate is null)
                return NotFound();
            
            return Ok(playlistUpdate);
        }

        [HttpDelete("{id}")]
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

        [HttpPut("{id}/Musics")]
        public ActionResult<PlaylistResponse> AddMusic([FromRoute] int id, [FromBody] PlaylistMusicDto musics)
        {
            musics.IdPlaylist = id;
            var movie = _playlistService.AddMusic(musics);

            if (movie is null)
                return NotFound();

            return Ok(movie);
        }

        [HttpDelete("{id}/Musics")]
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