using System;

namespace Exercise3
{
    class Solution
    {
        public int solution(int A, int B)
        {
            int count = 0;
            for (int i = A; i <= B; i++)
            {
                for (int j = 1; j * j <= i; j++)
                {
                    if (j * j == i)
                    {
                        count++;
                    }
                        
                }
                    
            }
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter A: ");
            int A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter B: ");
            int B = Convert.ToInt32(Console.ReadLine());
            Solution solution = new Solution();
            Console.WriteLine($"Result: {solution.solution(A, B)}");
        }
    }
}
