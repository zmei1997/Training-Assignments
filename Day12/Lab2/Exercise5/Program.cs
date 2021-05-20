using System;

namespace Exercise5
{
    class Box
    {
        public double Length { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public double Volume { get; set; }


        public double GetVolume()
        {
            if (Length == 0 && Breadth == 0 && Height == 0)
            {
                return Volume;
            }
            else
            {
                Volume = Length * Breadth * Height;
            }
            return Volume;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box();
            box1.Length = 10.5;
            box1.Breadth = 10.5;
            box1.Height = 10.5;
            Console.WriteLine($"Volume of Box1 : {box1.GetVolume()}");

            Box box2 = new Box();
            box2.Length = 20.5;
            box2.Breadth = 100.5;
            box2.Height = 30.5;
            Console.WriteLine($"Volume of Box2 : {box2.GetVolume()}");

            Box box3 = new Box();
            box3.Length = 200.5;
            box3.Breadth = 50.5;
            box3.Height = 60.5;
            //box3.Volume = box1.GetVolume() + box2.GetVolume();
            Console.WriteLine($"Volume of Box3 : {box3.GetVolume()}");
        }
    }
}
