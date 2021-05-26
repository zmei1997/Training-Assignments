using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            //BuiltInDelegate builtInDelegate = new BuiltInDelegate();

            //builtInDelegate.FuncDelegateExample();

            ManageCustomer manageCustomer = new ManageCustomer();
            manageCustomer.Print();
           
        }
    }
}
