using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            int amount = 1000;
            Console.WriteLine("Enter Your Pin Number");
            int pin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n********Welcome to ATM Service**************\n1. Check Balance\n2. Withdraw Cash\n3. Deposit Cash\n4. Quit\n*********************************************");
            
            while (!quit)
            {
                Console.WriteLine("\nEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("YOU’RE BALANCE IN Rs: {0}", amount);
                }
                if (choice == 2)
                {
                    Console.WriteLine("Withdraw amount: ");
                    amount -= Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("YOUR CURRENT BALANCE IN Rs: {0}", amount);
                }
                if (choice == 3)
                {
                    Console.WriteLine("Deposit amount: ");
                    amount += Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("YOUR CURRENT BALANCE IN Rs: {0}", amount);
                }
                if (choice == 4)
                {
                    Console.WriteLine("Quiting...");
                    quit = true;
                }
            }
        }
    }
}
