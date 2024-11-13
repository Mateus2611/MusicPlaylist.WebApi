using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories.EntityFramework
{
    public class EFMusicsPlaylists : IMusicsPlaylists
    {
        private readonly DataContext _context;

        public EFMusicsPlaylists(DataContext context) => _context = context;

        public void Add(MusicsPlaylists musicsPlaylists)
        {
            _context.MusicPlaylists.Add(musicsPlaylists);
            _context.SaveChanges();
        }

        public void Remove(MusicsPlaylists musicsPlaylists)
        {
            _context.MusicPlaylists.Remove(musicsPlaylists);
            _context.SaveChanges();
        }
    }
}