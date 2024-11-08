using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlaylist.WebApi.Repositories.EntityFramework
{
    public class EFGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public EFGenericRepository(DataContext context) => _context = context;

        public IEnumerable<T> GetAll()
            => _context.Set<T>().ToList();
        
        public T? Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T? Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}