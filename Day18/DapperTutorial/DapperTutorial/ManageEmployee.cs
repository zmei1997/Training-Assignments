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

        void AddEmployee()
        {
            Employee e = new Employee();
            Console.Write("Enter employee name: ");
            e.EName = Console.ReadLine();
            Console.Write("Enter employee salary: ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter employee departmentId: ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());
            empRepository.Insert(e);
        }

        void UpdateEmployeeSalary()
        {
            Console.Write("Enter the employee name you want to update: ");
            var name = Console.ReadLine();
            Console.Write("Enter a new salary: ");
            var salary = Convert.ToDecimal(Console.ReadLine());
            var collection = empRepository.GetAll();
            var employee = collection.Where(item => item.EName == name).FirstOrDefault();
            employee.Salary = salary;
            empRepository.Update(employee);
        }

        void UpdateEmployeeDept()
        {
            Console.Write("Enter the employee name you want to update: ");
            var name = Console.ReadLine();
            Console.Write("Enter a new department id: ");
            var deptid = Convert.ToInt32(Console.ReadLine());
            var collection = empRepository.GetAll();
            var employee = collection.Where(item => item.EName == name).FirstOrDefault();
            employee.DeptId = deptid;
            empRepository.Update(employee);
        }

        void DeleteEmployee()
        {
            Console.Write("Enter the employee name you want to delete: ");
            var name = Console.ReadLine();
            var collection = empRepository.GetAll();
            var employee = collection.Where(item => item.EName == name).FirstOrDefault();
            empRepository.Delete(employee.Id);
        }

        public void Run()
        {
            PrintAll();
            //AddEmployee();
            //UpdateEmployeeSalary();
            //UpdateEmployeeDept();
            //DeleteEmployee();
        }
    }
}
