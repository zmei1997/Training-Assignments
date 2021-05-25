using System;
using ConsoleApp4.ClientApp;
namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            //IArithematic arithematic = new ArithematicOperations();
            //arithematic.Addition(39, 12);
            //arithematic.Subtraction(28, 12);
            //arithematic.Multiply(42, 14);

            ManageDept manageDept = new ManageDept();
            manageDept.Run();

            Console.WriteLine("Hello World!");
        }
    }
}
