using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Comparison<string> comparison = new Comparison<string>();

            //comparison.AreEquals("Abc", "Abc");

            //Console.WriteLine("Hello World!");

            //ManageStudent manageStudent = new ManageStudent();
            //manageStudent.AddStudent();


            ManageDepartment manageDepartment = new ManageDepartment();
            manageDepartment.Run();
        }
    }
}
