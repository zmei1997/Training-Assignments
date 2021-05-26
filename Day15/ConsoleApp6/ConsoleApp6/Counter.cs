using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6
{

    public delegate void PrinterDelegate(int i);

    class Counter
    {
        public void StartCounting(PrinterDelegate del)
        {
            for (int i = 0; i < 10; i++)
            {
                del(i);
            }
        }
    }
}
