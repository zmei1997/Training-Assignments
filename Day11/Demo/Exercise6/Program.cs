using System;

namespace Exercise6
{
    class Program
    {
        static void displayDiamond(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }

            for (int i = n - 1; i >= 1; i--)
            {
                for (int j  = 1; j <= n - i; j++)
                    Console.Write(" ");
                for (int j  = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number of Rows: ");
            var input = Convert.ToInt32(Console.ReadLine());
            displayDiamond(input);
        }
    }
}
