using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlaylist.WebApi.Models.DTOs;
using MusicPlaylist.WebApi.Models.Responses;

namespace MusicPlaylist.WebApi.Services.Interfaces
{
    public interface IArtistService
    {
        ArtistResponse? Create(ArtistDto artist);

        IEnumerable<ArtistResponse> GetAll();

        ArtistResponse? Update(int id, ArtistDto artist);

        void Delete(int id);

        IEnumerable<ArtistResponse> GetByName(string name);

        ArtistResponse? GetById(int id);
    }
}