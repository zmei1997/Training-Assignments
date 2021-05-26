using System;
using ConsoleApp4.ClientApp;
using ConsoleApp4.Model;

namespace ConsoleApp4
{
    

    class Program
    {
     
        static void Main(string[] args)
        {
            int choice = 4;
            do
            {
                Console.Clear();

                MenuEnums menuEnums = new MenuEnums();
                menuEnums.PrintModelMenus();

                Console.Write("Enter your choice to manage => ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        ManageEmp manageEmp = new ManageEmp();
                        manageEmp.Run();
                        break;
                    case 2:
                        ManageCustomer manageCustomer = new ManageCustomer();
                        manageCustomer.Run();
                        break;
                    case 3:
                        ManageDept manageDept = new ManageDept();
                        manageDept.Run();
                        break;
                    case 4:
                        Console.WriteLine("Thanks for visit!!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            } while (choice != 4);
            Console.ReadLine();
        }
    }
}
