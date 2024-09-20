using EcommerceBackend.Core.Models;

namespace EcommerceBackend.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<Product> Products { get; }
        public IBaseRepository<Category> Categories { get; }

        public int Save();
    }
}
