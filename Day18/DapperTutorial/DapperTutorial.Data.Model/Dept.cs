using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTutorial.Data.Model
{
    public class Dept
    {
        private List<Employee> empCollection;
        public Dept()
        {
            empCollection = new List<Employee>();
        }
        public int Id { get; set; }
        public string DName { get; set; }
        public string Loc { get; set; }


        public List<Employee> Employees
        {
            get
            {
                return empCollection;
            }
            set
            {
                empCollection = value;
            }
        }


    }
}
