using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories
{
    public interface IMusicsPlaylists
    {
        void Add(MusicsPlaylists musicsPlaylists);

        void Remove(MusicsPlaylists musicsPlaylists);
    }
}