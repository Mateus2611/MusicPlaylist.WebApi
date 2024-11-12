using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories.EntityFramework
{
    public class EFPlaylistRepository : IPlaylistRepository
    {
        private readonly DataContext _context;

        public EFPlaylistRepository(DataContext context) => _context = context;

        public Playlist? Create(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            _context.SaveChanges();
            return playlist;
        }

        public void Delete(Playlist playlist)
        {
            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
        }

        public IEnumerable<Playlist> GetAll()
            => _context.Playlists
                .Include( playlist => playlist.Musics)
                .ToList();

        public Playlist? GetById(int id)
            => _context.Playlists
                .Include( playlist => playlist.Musics )
                .Single( playlist => playlist.Id == id);

        public IEnumerable<Playlist> GetByName(string name)
            => _context.Playlists
                .Include( playlist => playlist.Musics)
                .Where( playlist => playlist.Name.ToLower().Contains(name.ToLower()));

        public Playlist? Update(Playlist playlist)
        {
            _context.Update(playlist);
            _context.SaveChanges();
            return playlist;
        }
    }
}