using System;

namespace Exercise4
{
    class Solution
    {
        public void solution(int rows, int colns, int[,] a)
        {
            int currentRow = 0, currentColn = 0;

            while (currentRow < rows && currentColn < colns)
            {
                for (int i = currentColn; i < colns; i++)
                {
                    Console.Write(a[currentRow, i] + " ");
                }
                currentRow++;

                for (int i = currentRow; i < rows; i++)
                {
                    Console.Write(a[i, colns - 1] + " ");
                }
                colns--;

                if (currentRow < rows)
                {
                    for (int i = colns - 1; i >= currentColn; i--)
                    {
                        Console.Write(a[rows - 1, i] + " ");
                    }
                    rows--;
                }

                if (currentColn < colns)
                {
                    for (int i = rows - 1; i >= currentRow; i--)
                    {
                        Console.Write(a[i, currentColn] + " ");
                    }
                    currentColn++;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int r = 3, c = 3;
            int[,] A = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Solution solution = new Solution();
            solution.solution(r, c, A);
        }
    }
}
