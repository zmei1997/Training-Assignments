using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArithematicOperation arithematicOperation = new ArithematicOperation();
            //ArithematicDelegate del = new ArithematicDelegate(arithematicOperation.Add);
            //del(20, 10);

            Counter c = new Counter();
            Program p = new Program();
            PrinterDelegate printerDelegate = new PrinterDelegate(p.PrintValue);

            c.StartCounting(printerDelegate);


        }

        public void PrintValue(int i)
        {
            Console.WriteLine("this is printing inside Program class = " + i);
        }
    }
}
