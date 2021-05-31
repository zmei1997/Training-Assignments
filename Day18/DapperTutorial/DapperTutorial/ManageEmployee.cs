using System;
using System.Collections.Generic;
using System.Text;
using DapperTutorial.Data.Repository;
using DapperTutorial.Data.Model;
using System.Linq;
namespace DapperTutorial
{
    class ManageEmployee
    {
        IRepository<Employee> empRepository;
        public ManageEmployee()
        {
            empRepository = new EmployeeRepository();
        }
        void PrintAll()
        {
            var collection = empRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine(item.EName + "\t" + item.Dept.DName);
            }
        }

        public void Run()
        {
            PrintAll();
        }
    }
}
