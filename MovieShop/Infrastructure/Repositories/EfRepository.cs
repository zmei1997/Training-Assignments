using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;

        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            return entity;
        }

        public virtual IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().Where(filter).ToList();
        }

        public int GetCount(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().Where(filter).Count();
        }

        public bool GetExists(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().Where(filter).Any();
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
