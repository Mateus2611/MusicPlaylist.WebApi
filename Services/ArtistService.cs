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
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public ArtistResponse? Create(ArtistDto artist)
        {
            Artist newArtist = _mapper.Map<Artist>(artist);

            return
                _mapper.Map<ArtistResponse>
                (
                    _artistRepository.Create(newArtist)
                );
        }

        public void Delete(int id)
        {
            Artist artistDelete = _artistRepository.GetById(id) ?? throw new Exception("Artista não encontrado.");
            _artistRepository.Delete(artistDelete);
        }

        public IEnumerable<ArtistResponse> GetAll()
        {
            return
                _mapper.Map<IEnumerable<ArtistResponse>>
                (
                    _artistRepository.GetAll()
                );
        }

        public ArtistResponse? GetById(int id)
        {
            return
                _mapper.Map<ArtistResponse>
                (
                    _artistRepository.GetById(id)
                );
        }

        public IEnumerable<ArtistResponse> GetByName(string name)
        {
            return
                _mapper.Map<IEnumerable<ArtistResponse>>
                (
                    _artistRepository.GetByName(name)
                );
        }

        public ArtistResponse? Update(int id, ArtistUpdateDto artist)
        {
            Artist artistUpdate = _mapper.Map<Artist>(artist);
            artistUpdate.Id = id;

            return
                _mapper.Map<ArtistResponse>
                (
                    _artistRepository.Update(artistUpdate)
                ); 
        }
    }
}