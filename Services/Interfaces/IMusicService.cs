using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlaylist.WebApi.Models.DTOs;
using MusicPlaylist.WebApi.Models.Responses;

namespace MusicPlaylist.WebApi.Services.Interfaces
{
    public interface IMusicService
    {
        MusicResponse? Create(MusicDto music);

        IEnumerable<MusicResponse> GetAll();

        MusicResponse? Update(int id, MusicUpdateDto music);

        void Delete(int id);

        IEnumerable<MusicResponse> GetByName(string name);

        MusicResponse? GetById(int id);
    }
}