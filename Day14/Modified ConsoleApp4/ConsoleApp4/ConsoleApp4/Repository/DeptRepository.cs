using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp4.Model;
namespace ConsoleApp4.Repository
{
    public class DeptRepository : IRepository<Dept>
    {
        List<Dept> deptCollection = new List<Dept>();
        public void Add(Dept item)
        {
            deptCollection.Add(item);
        }

        public void Delete(int id)
        {
            Dept d = GetById(id);
            if (d != null)
            {
                deptCollection.Remove(d);
            }
        }

        public List<Dept> GetAll()
        {
            return deptCollection;
        }

        public Dept GetById(int id)
        {
            foreach (Dept item in deptCollection)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public void Update(Dept item)
        {
            Dept d = GetById(item.Id);
            if (d != null)
            {
                d.DName = item.DName;
                d.Location = item.Location;
            }
        }
    }
}
