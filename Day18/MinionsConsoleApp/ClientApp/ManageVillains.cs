using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository;
using Data.Model;

namespace ClientApp
{
    public class ManageVillains
    {
        VillainsRepository villainRepo;
        public ManageVillains()
        {
            villainRepo = new VillainsRepository();
        }

        void PrintVillainsWithNumOfMinions()
        {
            var map = villainRepo.GetVillainsWithNumOfMinions();
            if (map != null)
            {
                foreach (var item in map)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }

        void PrintAll()
        {
            var collection = villainRepo.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id} \t {item.Name} \t {item.EvilnessFactorId}");
            }
        }

        public void Run()
        {
            PrintVillainsWithNumOfMinions();
            //PrintAll();
        }
    }
}
