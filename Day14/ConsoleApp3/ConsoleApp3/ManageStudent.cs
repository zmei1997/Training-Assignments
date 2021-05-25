using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class ManageStudent
    {
        public void AddStudent() {
            List<string> studentCollection = new List<string>();
            studentCollection.Add("peter");
            studentCollection.Add("William");
            studentCollection.Add("David");
            studentCollection.Add("Jane");
            studentCollection.Add("Fracis");
            studentCollection.Add("Olivia");


            studentCollection.Remove("David");
            studentCollection.RemoveAt(1);

            

            foreach (string item in studentCollection)
            {
                Console.WriteLine(item);
            }

        }
    }
}
