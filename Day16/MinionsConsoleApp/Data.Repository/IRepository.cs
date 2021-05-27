using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public interface IRepository<T> where T:class
    {
        int Insert(T obj);
        int Delete(int id);
        int Update(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        int GetIdByName(string name);
    }
}
