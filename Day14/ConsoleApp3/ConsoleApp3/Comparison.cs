using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    /* if you are using object type then
     *  1. parameters are not type safe
     *  2. unwanted boxing and unboxing will happen 
     *       Boxing:- Conversion of a value to reference type
     *       Unboxig:- conversion of a reference to value type
     */
    class Comparison<T> where T:class
    {

        public bool AreEquals(object a, object b)
        {
            return a.Equals(b);
        }

        public bool AreEquals(T a, T b)
        {
            return a.Equals(b);
        }

    }
}
