using System;

namespace DapperTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageDepartment manageDepartment = new ManageDepartment();
            manageDepartment.Run();
            Console.Read();
        }
    }
}
