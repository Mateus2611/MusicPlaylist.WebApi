using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories.EntityFramework
{
    public class EFArtistRepository : EFGenericRepository<Artist>, IArtistRepository
    {
        private readonly DataContext _context;

        public EFArtistRepository(DataContext context) : base(context) => _context = context;

        public Artist? GetById(int id)
            => _context.Artists
                .Single( a => a.Id == id);

        public IEnumerable<Artist> GetByName(string name)
            => _context.Artists
                .Where(a => a.Name.ToLower().Contains(name.ToLower()))
                .ToList();
    }
}