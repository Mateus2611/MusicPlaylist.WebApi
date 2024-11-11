using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories.EntityFramework
{
    public class EFArtistRepository : IArtistRepository
    {
        private readonly DataContext _context;

        public EFArtistRepository(DataContext context) => _context = context;

        public IEnumerable<Artist> GetAll()
            => _context.Artists
            .Include( a => a.Musics )
            .ToList();
        
        public Artist? Create(Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
            return artist;
        }

        public Artist? Update(Artist artist)
        {
            _context.Artists.Update(artist);
            _context.SaveChanges();
            return artist;
        }

        public void Delete(Artist artist)
        {
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }

        public Artist? GetById(int id)
            => _context.Artists
                .Include( a => a.Musics )
                .Single( a => a.Id == id);

        public IEnumerable<Artist> GetByName(string name)
            => _context.Artists
                .Include( a => a.Musics)
                .Where(a => a.Name.ToLower().Contains(name.ToLower()))
                .ToList();
    }
}