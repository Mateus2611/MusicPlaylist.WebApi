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

            return 
                _mapper.Map<MusicResponse>
                (
                    _musicRepository.Create(newMusic)
                );
        }

        public void Delete(int id)
        {
            Music musicDelete = _musicRepository.GetById(id) ?? throw new Exception("Musica não encontrada.");
            _musicRepository.Delete(musicDelete);
        }

        public IEnumerable<MusicResponse> GetAll()
        {
            IEnumerable<MusicResponse> musics = 
            _mapper.Map<IEnumerable<MusicResponse>>
                (
                    _musicRepository.GetAll()
                );

            // foreach (MusicResponse music in musics)
            // {
            //     if ( music.Artist.Id > 0)
            //     {
            //         Artist artist = _artistRepository.GetById(music.Artist.Id) ?? throw new Exception("Música sem artista.");

            //         music.Artist.Name = artist.Name;
            //         music.Artist.Bio = artist.Bio;
            //     }
            // }

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
            Music musicUpdate = _mapper.Map<Music>(music);
            musicUpdate.Id = id;

            return
                _mapper.Map<MusicResponse>
                (
                    _musicRepository.Update(musicUpdate)
                );
        }
    }
}