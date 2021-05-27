using System;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManageVillains manageVillains = new ManageVillains();
            //manageVillains.Run();

            //ManageMinions manageMinions = new ManageMinions();
            //manageMinions.Run();

            ManageTowns manageTowns = new ManageTowns();
            manageTowns.Run();
        }
    }
}
