using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp4.Model;
using ConsoleApp4.Repository;

namespace ConsoleApp4.ClientApp
{
    class ManageDept
    {
        IRepository<Dept> deptRepository;
        public ManageDept()
        {
            deptRepository = new DeptRepository();
        }

        void AddDepartment()
        {
            Dept d = new Dept();
            Console.Write("Enter Id => ");
            d.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name => ");
            d.DName = Console.ReadLine();

            Console.Write("Enter Location => ");
            d.Location = Console.ReadLine();

            deptRepository.Add(d);
        }

        void PrintAllDepartments()
        {
            List<Dept> deptCollection = deptRepository.GetAll();
            if (deptCollection != null)
            {
                foreach (Dept item in deptCollection)
                {
                    Console.WriteLine($"{ item.Id} \t {item.DName} \t {item.Location}");
                }

            }
        }

        void DeleteDepartment()
        {
            Console.Write("Enter Id => ");
            int id = Convert.ToInt32(Console.ReadLine());
            deptRepository.Delete(id);
        }

        void UpdateDepartment()
        {
            Dept d = new Dept();
            Console.Write("Enter Id => ");
            d.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name => ");
            d.DName = Console.ReadLine();

            Console.Write("Enter Location => ");
            d.Location = Console.ReadLine();

            deptRepository.Update(d);
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
                        AddDepartment();
                        break;
                    case 2:
                        DeleteDepartment();
                        break;
                    case 3:
                        UpdateDepartment();
                        break;
                    case 4:
                        PrintAllDepartments();
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
