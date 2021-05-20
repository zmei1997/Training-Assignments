using System;

namespace Exercise2
{
    class Solution 
    { 
        public int solution(int[] A)
        {
            Array.Sort(A);
            int count = 1, maxCount = 1, res = 0;

            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] == A[i - 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        res = A[i - 1];
                    }
                    count = 1;
                }
            }

            if (count > maxCount)
            {
                maxCount = count;
                res = A[A.Length - 1];
            }
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size: ");
            int[] A = new int[Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine("Enter array values: e.g.: 10,20,30,30,20");
            string[] As = Console.ReadLine().Split(",");
            for (int i = 0; i < As.Length; i++)
            {
                A[i] = Convert.ToInt32(As[i]);
            }
            Solution solution = new Solution();
            Console.WriteLine(solution.solution(A));
        }
    }
}
