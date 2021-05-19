using System;

namespace Exercise5
{
    class Program
    {
        static void printBinaryTriangle(int n)
        {
            int last_Int = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (last_Int == 1)
                    {
                        Console.Write("0");
                        last_Int = 0;
                    }
                    else if (last_Int == 0)
                    {
                        Console.Write("1");
                        last_Int = 1;
                    }
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number of Rows: ");
            var input = Convert.ToInt32(Console.ReadLine());
            printBinaryTriangle(input);
        }
    }
}
