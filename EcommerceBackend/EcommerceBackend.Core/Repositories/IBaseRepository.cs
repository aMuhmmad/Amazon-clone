using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBackend.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> match);
        T Find(Expression<Func<T, bool>> match, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip);

        T Add(T entity);
        IEnumerable<T> Add(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
    }
}
