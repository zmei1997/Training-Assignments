using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{
    public delegate void ArithematicDelegate(int a, int b);
    class ArithematicOperation
    {
        public void Add(int a, int b)
        {
            Console.WriteLine($"Sum ={a + b}");
        }
        public void Subtract(int a, int b)
        {
            Console.WriteLine($"Subtraction ={a - b}");
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
