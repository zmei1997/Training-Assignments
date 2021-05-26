using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Model
{
    public enum Menu
    {
        insert = 1,
        delete,
        update,
        printAll,
        exit
    }

    public enum SelectOneModelToOperate
    {
        Employee = 1,
        Customer,
        Department,
        Quit
    }

    class MenuEnums
    {
        public void PrintModelMenus()
        {
            int[] values = (int[])Enum.GetValues(typeof(SelectOneModelToOperate));
            string[] name = Enum.GetNames(typeof(SelectOneModelToOperate));

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"press {values[i]} to manage {name[i]}");
            }
        }

        public void PrintMenus()
        {
            int[] values = (int[])Enum.GetValues(typeof(Menu));
            string[] name = Enum.GetNames(typeof(Menu));

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"press {values[i]} to {name[i]}");
            }
        } 
    }
}
