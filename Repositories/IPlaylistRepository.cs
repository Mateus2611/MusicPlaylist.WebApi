using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories
{
    public interface IPlaylistRepository
    {
        Playlist? Create(Playlist playlist);

        IEnumerable<Playlist> GetAll();

        Playlist? Update(Playlist playlist);

        void Delete(Playlist playlist);

        IEnumerable<Playlist> GetByName(string name);

        Playlist? GetById(int id);
    }
}