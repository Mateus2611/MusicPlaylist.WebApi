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

        Artist? Update(Artist artist);

        void Delete(Artist artist);

        IEnumerable<Music> GetByName(string name);

        Music? GetById(int id);
    }
}