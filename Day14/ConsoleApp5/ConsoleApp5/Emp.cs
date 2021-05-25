using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class Emp
    {
        private int age;
        public int Id { get; set; }
        public int Age
        {
            get { return age; }
            set
            {

                if (value < 20 || value > 55)
                    throw new AgeException();
                else
                    age = value;
            }
        }
    }
}
