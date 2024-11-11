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

        [HttpGet]
        public ActionResult<IEnumerable<MusicResponse>> Get([FromQuery(Name = "name")] string? name)
        {
            if (name is not null)
                return Ok(_musicService.GetByName(name));

            return Ok(_musicService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<MusicResponse> GetById([FromRoute(Name = "id")] int id)
        {
            MusicResponse? music = _musicService.GetById(id);

            if (music is null)
                return NotFound();
            
            return Ok(music);            
        }

        [HttpPost]
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

        [HttpPut("{id}")]
        public ActionResult<MusicResponse> Update([FromRoute(Name = "id")] int id, [FromBody] MusicUpdateDto music)
        {
            MusicResponse? musicUpdate = _musicService.Update(id, music);

            if (musicUpdate is null)
                return NotFound();
            
            return Ok(musicUpdate);
        }

        [HttpDelete("{id}")]
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