using System;

namespace Exercise4
{
    class Program
    {
        static bool checkArmstrongNumber(int n)
        {
            int r, temp = n, sum = 0;
            while (n > 0)
            {
                r = n % 10;
                sum = sum + (r * r * r);
                n = n / 10;
            }
            if (temp == sum)
                return true;
            else
                return false;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number: ");
            int fn = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            int sn = Convert.ToInt32(Console.ReadLine());
            for (int i = fn; i <= sn; i++)
            {
                if (checkArmstrongNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
