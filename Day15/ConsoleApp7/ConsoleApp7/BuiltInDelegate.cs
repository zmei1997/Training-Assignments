using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7
{
    /*
     * Action<T> :- it can take any generic input but does not return any value (void)
     * Predicate<T> :- it can take any generic input but returns bool value
     * Func<T1 in, T2 out>:- it can take any generic input and can return any generic output
     */
    class BuiltInDelegate
    {
        public void ActionDelegateExample()
        {

            Action<int> primeDelegate = (number) =>
           {
               if (number > 0 && number < 4)
               {
                   Console.WriteLine("Prime Number");
               }
               else
               {
                   bool flag = true;
                   for (int i = 2; i < number / 2; i++)
                   {
                       if (number % i == 0)
                       {
                           flag = false;
                           break;
                       }
                   }
                   if (flag)
                       Console.WriteLine("Prime Number");
                   else
                       Console.WriteLine("Not a prime number");
               }
           };
            primeDelegate(29);
        }


        public void PredicateDelegateExample()
        {

            Predicate<int> leapYearDelegate = (year) => DateTime.IsLeapYear(year);

            bool result = leapYearDelegate(2020);
            Console.WriteLine($"Result =  {result}");
        }

        public void FuncDelegateExample()
        {
            Func<int, string> fibbonacciDelegate = (length) =>
            {
                int a = 0, b = 1, c = 0;
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    result.Append(a + " ");
                    c = a + b;
                    a = b;
                    b = c;
                }
                return result.ToString();
            };
            string result = fibbonacciDelegate(7);
            Console.WriteLine(result);
        }



    }
}
