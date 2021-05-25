using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Emp e = new Emp();
                Console.Write("Enter id => ");
                e.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Age => ");
                e.Age = Convert.ToInt32(Console.ReadLine());
                

                Console.WriteLine("Id = " + e.Id+" \t age= "+e.Age);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            catch (AgeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
