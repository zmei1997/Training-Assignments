using System;

namespace Exercise2
{
    public class Arithmetic
    {
        public int a, b;

        public void addition()
        {
            Console.WriteLine("addition :");
            Console.WriteLine(a+b);
        }

        public void subtraction()
        {
            Console.WriteLine("subtraction :");
            Console.WriteLine(a - b);
        }

        public void multiplication()
        {
            Console.WriteLine("multiplication :");
            Console.WriteLine(a * b);
        }

        public void division()
        {
            Console.WriteLine("division :");
            Console.WriteLine(a / b);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var arth = new Arithmetic();
            arth.a = 6;
            arth.b = 3;
            Console.WriteLine("a is {0}, b is {1} \n", arth.a, arth.b);
            arth.addition();
            arth.subtraction();
            arth.multiplication();
            arth.division();
        }
    }
}
