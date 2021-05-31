using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace DapperTutorial.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        int Insert(T item);
        int Delete(int id);
        int Update(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }


    public interface IRepositoryAsync<T> where T : class
    {
        Task<int> InsertAsync(T item);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T item);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }

}
