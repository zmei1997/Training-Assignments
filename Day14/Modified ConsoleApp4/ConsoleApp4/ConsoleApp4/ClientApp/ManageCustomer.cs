using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp4.Repository;
using ConsoleApp4.Model;

namespace ConsoleApp4.ClientApp
{
    class ManageCustomer
    {
        IRepository<Customer> customerRepository;

        public ManageCustomer()
        {
            customerRepository = new CustomerRepository();
        }

        void AddCustomer()
        {
            Customer c = new Customer();
            Console.Write("Enter Id => ");
            c.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter FullName => ");
            c.FullName = Console.ReadLine();

            Console.Write("Enter City => ");
            c.City = Console.ReadLine();

            customerRepository.Add(c);
        }

        void PrintAllCustomers()
        {
            List<Customer> customerCollection = customerRepository.GetAll();
            if (customerCollection != null)
            {
                foreach (Customer item in customerCollection)
                {
                    Console.WriteLine($"{item.Id} \t {item.FullName} \t {item.City}");
                }

            }
        }

        void DeleteCustomer()
        {
            Console.Write("Enter Id => ");
            int id = Convert.ToInt32(Console.ReadLine());
            customerRepository.Delete(id);
        }

        void UpdateCustomer()
        {
            Customer c = new Customer();
            Console.Write("Enter Id => ");
            c.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter FullName => ");
            c.FullName = Console.ReadLine();

            Console.Write("Enter City => ");
            c.City = Console.ReadLine();

            customerRepository.Update(c);
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
                        AddCustomer();
                        break;
                    case 2:
                        DeleteCustomer();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        PrintAllCustomers();
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
