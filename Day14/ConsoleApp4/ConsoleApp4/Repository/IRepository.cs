using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Repository
{
    interface IRepository<T> where T : class
    {
        void Add(T item);
        void Delete(int id);

        List<T> GetAll();

        T GetById(int id);

        void Update(T item);
    }
}
