using System;

namespace Exercise5
{
    class ComplexNumber
    {
        private int real;
        private int imaginary;

        public ComplexNumber(int a, int b)
        {
            this.real = a;
            this.imaginary = b;
        }

        public void SetReal(int a)
        {
            real = a;
        }

        public int GetReal()
        {
            return real;
        }

        public void SetImaginary(int b)
        {
            imaginary = b;
        }

        public int GetImaginary()
        {
            return imaginary;
        }

        public new string ToString()
        {
            return $"({real},{imaginary})";
        }

        public double GetMagnitude()
        {
            return Math.Sqrt(real * real + imaginary * imaginary);
        }

        public void Add(ComplexNumber n)
        {
            this.real = this.real + n.real;
            this.imaginary = this.imaginary + n.imaginary;
        }
    }

    class ComplexTest
    {
        static void Main(string[] args)
        {
            bool debug = false;

            ComplexNumber number = new ComplexNumber(5, 2);
            Console.WriteLine("Number is: " + number.ToString());

            number.SetImaginary(-3);
            Console.WriteLine("Number is: " + number.ToString());

            Console.Write("Magnitude is: ");
            Console.WriteLine(number.GetMagnitude());

            ComplexNumber number2 = new ComplexNumber(-1, 1);
            number.Add(number2);
            Console.Write("After adding: ");
            Console.WriteLine(number.ToString());

            if (debug)
                Console.ReadLine();
            Console.ReadKey();

        }
    }
}
