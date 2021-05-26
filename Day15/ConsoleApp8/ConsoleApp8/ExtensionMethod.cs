using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    /*
     *  1. Class must be static
     *  2. extension method must be static method
     *  3. first parameter to the extension must be of type you want to extend to.
     *  4. first parameter must be written after this keyword
     */

    static class ExtensionMethod
    {
        public static bool IsPrime(this int number)
        {
            if (number > 0 && number < 4)
                return true;
            for (int i = 2; i < number / 2; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
