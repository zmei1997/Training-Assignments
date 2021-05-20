using System;
using System.Collections.Generic;

namespace Exercise3
{
    public class Record
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }

        public Record(string date, string desc, string catag, decimal amount)
        {
            this.Date = date;
            this.Description = desc;
            this.Category = catag;
            this.Amount = amount;
        }
    }

    public class HouseholdAccounts
    {
        List<Record> recordList;
        public HouseholdAccounts()
        {
            recordList = new List<Record>();
        }

        public void AddNew(string date, string desc, string catag, decimal amount)
        {
            Record newRecord = new Record(date, desc, catag, amount);
            recordList.Add(newRecord);
            Console.WriteLine($"Number of Record: {recordList.Count}");
        }

        public void ShowAllByCategory(string catag)
        {
            for (int i = 0; i < recordList.Count; i++)
            {
                if (recordList[i].Category.Equals(catag))
                {
                    Console.WriteLine($"Number of Record: {recordList.Count}");
                    Console.WriteLine($"{recordList[i].Date} {recordList[i].Description} {recordList[i].Category} {recordList[i].Amount}");
                }
            }
        }

        public void SearchByText(string text)
        {
            for (int i = 0; i < recordList.Count; i++)
            {
                if (recordList[i].Category.Equals(text) || recordList[i].Description.Contains(text))
                {
                    Console.WriteLine($"Number of Record: {recordList.Count}");
                    Console.WriteLine($"{recordList[i].Date} {recordList[i].Description} {recordList[i].Category} {recordList[i].Amount}");
                }
            }
        }

        public void DeleteByDate(string date)
        {
            for (int i = 0; i < recordList.Count; i++)
            {
                if (recordList[i].Date.Equals(date))
                {
                    Console.WriteLine($"Number of Record: {recordList.Count}");
                    Console.WriteLine($"{recordList[i].Date} {recordList[i].Description} {recordList[i].Category} {recordList[i].Amount}");
                }
            }
        }
    }

    enum Operations
    {
        AddNew = 1,
        ShowAllByCategory,
        SearchByText,
        DeleteByDate,
        Exit
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = (int[])Enum.GetValues(typeof(Operations));
            string[] name = Enum.GetNames(typeof(Operations));
            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine($"{numbers[i]}. {name[i]}");
            }
            HouseholdAccounts householdAccounts = new HouseholdAccounts();
            bool repeat = true;
            while (repeat)
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case (int)Operations.AddNew:
                        Console.Write("Date: ");
                        string date = Console.ReadLine();
                        Console.Write("Description: ");
                        string desc = Console.ReadLine();
                        Console.Write("Category: ");
                        string catag = Console.ReadLine();
                        Console.Write("Amount: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        householdAccounts.AddNew(date, desc, catag, amount);
                        break;
                    case (int)Operations.ShowAllByCategory:
                        Console.Write("Show All By Category: ");
                        string text = Console.ReadLine();
                        householdAccounts.ShowAllByCategory(text);
                        break;
                    case (int)Operations.SearchByText:
                        Console.Write("Search By Text: ");
                        string text2 = Console.ReadLine();
                        householdAccounts.SearchByText(text2);
                        break;
                    case (int)Operations.DeleteByDate:
                        Console.Write("Delete By Date: ");
                        string text3 = Console.ReadLine();
                        householdAccounts.SearchByText(text3);
                        break;
                    case (int)Operations.Exit:
                        repeat = false;
                        break;
                }
            }
        }
    }
}
