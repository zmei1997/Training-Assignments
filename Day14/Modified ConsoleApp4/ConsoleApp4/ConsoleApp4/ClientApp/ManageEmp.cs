using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp4.Repository;
using ConsoleApp4.Model;

namespace ConsoleApp4.ClientApp
{
    class ManageEmp
    {
        IRepository<Employee> empRepository;
        public ManageEmp()
        {
            empRepository = new EmpRepository();
        }

        void AddEmployee()
        {
            Employee e = new Employee();
            Console.Write("Enter Id => ");
            e.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter FullName => ");
            e.FullName = Console.ReadLine();

            Console.Write("Enter Salary => ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());

            empRepository.Add(e);
        }

        void PrintAllEmployees()
        {
            List<Employee> employeeCollection = empRepository.GetAll();
            if (employeeCollection != null)
            {
                foreach (Employee item in employeeCollection)
                {
                    Console.WriteLine($"{item.Id} \t {item.FullName} \t {item.Salary}");
                }
            }
        }

        void DeleteEmployee()
        {
            Console.Write("Enter Id => ");
            int id = Convert.ToInt32(Console.ReadLine());
            empRepository.Delete(id);
        }

        void UpdateEmployee()
        {
            Employee e = new Employee();
            Console.Write("Enter Id => ");
            e.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter FullName => ");
            e.FullName = Console.ReadLine();

            Console.Write("Enter Salary => ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());
            empRepository.Update(e);
            
        }

        public void Run()
        {
            int choice = 5;
            do
            {
                Console.Clear();

                MenuEnums menuEnums = new MenuEnums();
                menuEnums.PrintMenus();

                Console.Write("Enter your choice => ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        DeleteEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        PrintAllEmployees();
                        break;
                    case 5:
                        Console.WriteLine("Thanks for visit!!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                Console.ReadLine();
            } while (choice != 5);
        }
    }
}
