using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories
{
    public interface IArtistRepository
    {
        Artist? Create(Artist artist);
        
        IEnumerable<Artist> GetAll();

        Artist? Update(Artist artist);

        void Delete(Artist artist);

        IEnumerable<Artist> GetByName(string name);

        Artist? GetById(int id);
    }
}