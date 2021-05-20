using System;

namespace Exercise1
{
    public abstract class Shape1
    {

        protected float R, L, B;

        //Abstract methods can have only declarations
        public abstract float Area();
        public abstract float Circumference();

    }

    public class Rectangle : Shape1
    {
        public Rectangle()
        {
            Console.Write("Enter Length: ");
            L = (float)Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Breadth: ");
            B = (float)Convert.ToDecimal(Console.ReadLine());
        }

        public override float Area()
        {
            return L * B;
        }

        public override float Circumference()
        {
            return 2 * (L + B);
        }
    }

    public class Circle : Shape1
    {
        public Circle()
        {
            Console.Write("Enter Radius : ");
            R = (float)Convert.ToDecimal(Console.ReadLine());
        }

        public override float Area()
        {
            return 3.14f * R * R;
        }

        public override float Circumference()
        {
            return 2 * 3.14f * R;
        }
    }

    class Program
    {
        public static void Calculate(Shape1 S)
        {

            Console.WriteLine("Area : {0}", S.Area());
            Console.WriteLine("Circumference : {0}\n", S.Circumference());

        }

        static void Main(string[] args)
        {
            Shape1 rectangle = new Rectangle();
            Calculate(rectangle);
            Shape1 circle = new Circle();
            Calculate(circle);
        }
    }
}
