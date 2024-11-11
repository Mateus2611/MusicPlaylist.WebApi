using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPlaylist.WebApi.Models;

namespace MusicPlaylist.WebApi.Repositories.EntityFramework
{
    public class EFMusicRepository : EFGenericRepository<Music>, IMusicRepository
    {
        private readonly DataContext _context;

        public EFMusicRepository(DataContext context) : base(context) => _context = context;

        public Music? GetById(int id)
            => _context.Musics
                .Single( m => m.Id == id);

        public IEnumerable<Music> GetByName(string name)
            => _context.Musics
                .Where( m => m.Name.ToLower().Contains(name.ToLower()));
    }
}