using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using Data.Repository;

namespace ClientApp
{
    public class ManageTowns
    {
        TownsRepository townsRepository;
        CountryRepository countryRepository;
        public ManageTowns()
        {
            townsRepository = new TownsRepository();
            countryRepository = new CountryRepository();
        }

        public void CastTownNameByCountry()
        {
            Console.Write("Enter a country name: ");
            string name = Console.ReadLine();
            // check if the country existed
            int gottenCountryId = countryRepository.GetIdByName(name);
            // if exist
            if (gottenCountryId != 0)
            {
                List<string> listOfTownName = townsRepository.UpperTownNamesByCountry(name);
                if (listOfTownName.Count > 0)
                {
                    Console.WriteLine($"{listOfTownName.Count} town names were affected.");
                    Console.WriteLine("[" + string.Join(", ", listOfTownName) + "]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
            else
                Console.WriteLine("No town names were affected.");
        }

        public void Run()
        {
            CastTownNameByCountry();
        }
    }
}
