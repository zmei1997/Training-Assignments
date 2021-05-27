using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using Data.Repository;

namespace ClientApp
{
    public class ManageMinions
    {
        MinionsRepository minionsRepository;
        VillainsRepository villainsRepository;
        TownsRepository townsRepository;
        MinionsVillainsRepository minionsVillainsRepository;
        public ManageMinions()
        {
            minionsRepository = new MinionsRepository();
            villainsRepository = new VillainsRepository();
            townsRepository = new TownsRepository();
            minionsVillainsRepository = new MinionsVillainsRepository();
        }

        public void PrintMinionByVillainId()
        {
            Console.Write("Enter id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var map = minionsRepository.GetMinionByVillainId(id);

            // Check if there is no villain with the given ID
            var villainById = villainsRepository.GetById(id);
            if (villainById.Name != null)
            {
                Console.WriteLine($"Villain: {villainById.Name}");

                // Print all Minion by villain
                int index = 1;
                foreach (var item in map)
                {
                    Console.WriteLine($"{index++}. {item.Key} {item.Value}");
                }
            }
            else // Otherwise print error message 
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
        }

        public void AddMinion()
        {
            Minions m = new Minions();
            Console.Write("Minion: ");
            string input = Console.ReadLine();
            string[] arrayInput = input.Split(" ");
            m.Name = arrayInput[0];
            m.Age = Convert.ToInt32(arrayInput[1]);
            string townName = arrayInput[2];
            
            int gottenTownId = townsRepository.GetIdByName(townName);
            // Check if the townName existed
            if (gottenTownId != 0)
            {
                m.TownId = gottenTownId;
                minionsRepository.Insert(m);
            }
            else // otherwise, create a new Town
            {
                Towns t = new Towns();
                t.Name = townName;
                t.CountryId = 1;
                townsRepository.Insert(t);
                m.TownId = townsRepository.GetIdByName(t.Name);
                minionsRepository.Insert(m);
                Console.WriteLine($"Town {t.Name} was added to the database.");
            }
            

            Console.Write("Villain: ");
            string vName = Console.ReadLine();
            int gottenVillainId = villainsRepository.GetIdByName(vName);
            if (gottenVillainId != 0)
            {
                MinionsVillains mv = new MinionsVillains();
                mv.MinionId = minionsRepository.GetIdByName(m.Name);
                mv.VillainId = gottenVillainId;
                minionsVillainsRepository.Insert(mv);
                Console.WriteLine($"Successfully added {m.Name} to be minion of {vName}.");
            }
            else
            {
                Villains v = new Villains();
                v.Name = vName;
                v.EvilnessFactorId = 4;
                villainsRepository.Insert(v);
                MinionsVillains mv2 = new MinionsVillains();
                mv2.MinionId = minionsRepository.GetIdByName(m.Name);
                mv2.VillainId = villainsRepository.GetIdByName(vName);
                minionsVillainsRepository.Insert(mv2);
                Console.WriteLine($"Successfully added {m.Name} to be minion of {vName}.");
            }

        }

        public void Run()
        {
            //PrintMinionByVillainId();
            AddMinion();
        }
    }
}
