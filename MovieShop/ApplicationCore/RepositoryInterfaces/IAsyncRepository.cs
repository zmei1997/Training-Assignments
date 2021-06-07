using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> ListAll();
        IEnumerable<T> List(Expression<Func<T, bool>> filter);
        int GetCount(Expression<Func<T, bool>> filter);
        bool GetExists(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
