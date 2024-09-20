using EcommerceBackend.Core.Models;
using EcommerceBackend.Core.Repositories;
using EcommerceBackend.Infrastructure.Repositories;

namespace EcommerceBackend.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Product> Products { get; }

        public IBaseRepository<Category> Categories { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new BaseRepository<Product>(_context);
            Categories = new BaseRepository<Category>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
