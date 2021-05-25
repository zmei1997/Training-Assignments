using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3.Model;

namespace ConsoleApp3
{
    class ManageDepartment
    {
        List<Department> deptCollection = new List<Department>();
        void AddDepartment(Department department)
        {
            deptCollection.Add(department);
        }
        void PrintDepartment()
        {
            foreach (Department item in deptCollection)
            {
                Console.WriteLine($"{item.Id} \t {item.DName} \t {item.Location}");
            }
        }


        public void Run()
        {
            Department d = new Department();
            d.Id = 1;
            d.DName = "IT";
            d.Location = "Sterling";

            AddDepartment(d);

            AddDepartment(new Department() { Id = 2, DName = "HR", Location = "Naperville" });
            AddDepartment(new Department() { Id = 3, DName = "QA", Location = "Reston" });


            PrintDepartment();
        }
    }
}
