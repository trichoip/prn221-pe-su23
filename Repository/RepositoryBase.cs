using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryBase<T> where T : class
    {
        private readonly MovieManagementDBContext _context;
        public RepositoryBase()
        {
            _context = new MovieManagementDBContext();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveAll(IQueryable<T> entitys)
        {
            _context.Set<T>().RemoveRange(entitys);
            _context.SaveChanges();
        }
    }
}
