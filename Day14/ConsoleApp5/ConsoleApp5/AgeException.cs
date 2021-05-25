using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class AgeException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "Age must be in between 20 to 55";
            }
        }
    }
}
