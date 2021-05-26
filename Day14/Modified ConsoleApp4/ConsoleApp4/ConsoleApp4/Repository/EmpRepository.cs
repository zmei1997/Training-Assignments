using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp4.Model;
namespace ConsoleApp4.Repository
{
    class EmpRepository : IRepository<Employee>
    {
        List<Employee> employeeCollection = new List<Employee>();
        public void Add(Employee item)
        {
            employeeCollection.Add(item);
        }

        public void Delete(int id)
        {
            Employee e = GetById(id);
            if (e != null)
            {
                employeeCollection.Remove(e);
            }
        }

        public List<Employee> GetAll()
        {
            return employeeCollection;
        }

        public Employee GetById(int id)
        {
            foreach(Employee item in employeeCollection)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void Update(Employee item)
        {
            Employee e = GetById(item.Id);
            if (e != null)
            {
                e.FullName = item.FullName;
                e.Salary = item.Salary;
            }
        }
    }
}
