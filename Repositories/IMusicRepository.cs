using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories
{
    public interface IMusicRepository
    {
        Music? Create(Music music);

        IEnumerable<Music> GetAll();

        Music? Update(Music music);

        void Delete(Music music);

        IEnumerable<Music> GetByName(string name);

        Music? GetById(int id);
    }
}