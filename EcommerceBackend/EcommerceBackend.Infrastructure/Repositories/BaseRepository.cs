using EcommerceBackend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceBackend.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public IEnumerable<T> Add(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();

            return entities;
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes)
        {
            var query = _context.Set<T>().Where(match);

            foreach (var include in includes)
                query = query.Include(include);


            return query.SingleOrDefault();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes)
        {
            var query = _context.Set<T>().Where(match);

            foreach (var include in includes)
                query = query.Include(include);


            return query.ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip)
        {
            return _context.Set<T>().Where(match).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
