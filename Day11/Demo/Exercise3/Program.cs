using System;
using System.Text;

namespace Exercise3
{
    class Program
    {
        static string reverseString(string s)
        {
            StringBuilder str = new StringBuilder();
            for (int i = s.ToCharArray().Length-1; i >= 0; i--)
            {
                str.Append(s.ToCharArray()[i]);
            }
            return str.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string input = Console.ReadLine();
            Console.WriteLine("\nOutput: ");
            Console.WriteLine(reverseString(input));
        }
    }
}
