using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp = new Employee() { Id = 1, Name = "Smith", Salary = 6700 };
            emp.Name = "Peter";

            var dept = new { Id = 1, Name = "IT", Location = "Sterling" };
            //dept.Name = "Testing";


            int a = 53;
            bool result = a.IsPrime();
            Console.WriteLine(result);
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
