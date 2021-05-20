using System;

namespace Exercise4
{
    public class Person
    {
        protected int age;

        public Person()
        {
            Console.WriteLine("Hello");
        }

        public void SetAge(int n)
        {
            age = n;
        }
    }

    public class Student: Person
    {
         public void GoToClasses()
        {
            Console.WriteLine("I’m going to class.");
        }

        public void ShowAge()
        {
            Console.WriteLine($"My age is: {age} years old.");
        }
    }

    public class Teacher: Person
    {
        private string subject;

        public void Explain()
        {
            Console.WriteLine("Explanation begins");
        }
    }

    class StudentAndTeacherTest
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Student student = new Student();
            student.SetAge(21);
            student.ShowAge();
            Teacher teacher = new Teacher();
            teacher.Explain();
        }
    }
}
