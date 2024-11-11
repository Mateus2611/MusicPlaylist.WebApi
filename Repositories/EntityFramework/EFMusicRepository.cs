using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories.EntityFramework
{
    public class EFMusicRepository : IMusicRepository
    {
        private readonly DataContext _context;

        public EFMusicRepository(DataContext context) => _context = context;

        public IEnumerable<Music> GetAll()
        {
            var result = _context.Musics
                .Include( music => music.Artists )
                .ToList();

            return result;
        }

        public Music? Create(Music music)
        {
            _context.Musics.Add(music);
            _context.SaveChanges();
            return music;
        }

        public Music? Update(Music music)
        {
            _context.Musics.Update(music);
            _context.SaveChanges();
            return music;
        }

        public void Delete(Music music)
        {
            _context.Musics.Remove(music);
            _context.SaveChanges();
        }

        public Music? GetById(int id)
        {
            var result = 
                _context.Musics
                    .Include( music => music.Artists )
                    .Single( music => music.Id == id );

            return result;
        }

        public IEnumerable<Music> GetByName(string name)
        {
            var result = 
                _context.Musics
                    .Include( music => music.Artists )
                    .Where( music => music.Name.ToLower().Contains(name.ToLower()));
            
            return result;
        }
    }
}