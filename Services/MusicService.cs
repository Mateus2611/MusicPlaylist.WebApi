using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MusicPlaylist.WebApi.Models;
using MusicPlaylist.WebApi.Models.DTOs;
using MusicPlaylist.WebApi.Models.Responses;
using MusicPlaylist.WebApi.Repositories;
using MusicPlaylist.WebApi.Services.Interfaces;

namespace MusicPlaylist.WebApi.Services
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _musicRepository;

        private readonly IArtistRepository _artistRepository;

        private readonly IMapper _mapper;

        public MusicService(IMapper mapper, IMusicRepository musicRepository, IArtistRepository artistRepository)
        {
            _mapper = mapper;
            _musicRepository = musicRepository;
            _artistRepository = artistRepository;
        }

        public MusicResponse? Create(MusicDto music)
        {
            Music newMusic = _mapper.Map<Music>(music);

            Artist musicArtist = _artistRepository.GetById(music.ArtistId) ?? throw new Exception("Artista não encontrado.");

            newMusic.ArtistId = musicArtist.Id;

            var result = _musicRepository.Create(newMusic);

            if ( result is not null )
                result.Artists = musicArtist;

            return _mapper.Map<MusicResponse>(result);
        }

        public void Delete(int id)
        {
            Music musicDelete = _musicRepository.GetById(id) ?? throw new Exception("Musica não encontrada.");
            _musicRepository.Delete(musicDelete);
        }

        public IEnumerable<MusicResponse> GetAll()
        {
            var musics = 
                _mapper.Map<IEnumerable<MusicResponse>>
                    (
                        _musicRepository.GetAll()
                    );

            return musics;
        }

        public MusicResponse? GetById(int id)
        {
            return
                _mapper.Map<MusicResponse>
                (
                    _musicRepository.GetById(id)
                );
        }

        public IEnumerable<MusicResponse> GetByName(string name)
        {
            return
                _mapper.Map<IEnumerable<MusicResponse>>
                (
                    _musicRepository.GetByName(name)
                );
        }

        public MusicResponse? Update(int id, MusicUpdateDto music)
        {
            Music oldMusic = _musicRepository.GetById(id) ?? throw new Exception("Música não encontrada.");
            Artist artistMusic = _artistRepository.GetById(music.ArtistId) ?? throw new Exception("Artista não encontrado.");
            
            Music musicUpdated = new() 
            {
                Id = oldMusic.Id,
                Name = music.Name ?? oldMusic.Name,
                Release = music.Release,
                ArtistId = music.ArtistId,
                Artists = artistMusic
            };

            return 
                _mapper.Map<MusicResponse>
                (
                    _musicRepository.Update(musicUpdated)
                );
        }
    }
}