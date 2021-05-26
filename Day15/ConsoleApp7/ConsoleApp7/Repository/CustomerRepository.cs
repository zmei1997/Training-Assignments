using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7.Repository
{
    class CustomerRepository
    {
        List<Customer> customerCollection;
        public CustomerRepository()
        {
            customerCollection = new List<Customer> {
               new Customer(){Id=1, Name="David", City="Sterling", Country="USA" },
               new Customer(){Id=2, Name="Fracis", City="Paris", Country="France" },
               new Customer(){Id=3, Name="Simon", City="London", Country="UK" },
               new Customer(){Id=4, Name="Ryan", City="Sterling", Country="USA" },
               new Customer(){Id=5, Name="Pam", City="Perth", Country="Australia" },
               new Customer(){Id=6, Name="Pam", City="London", Country="UK" },
               new Customer(){Id=7, Name="Miller", City="Tysons", Country="USA" }
            };
        }

        public List<Customer> WhereClause(Predicate<Customer> del)
        {
            List<Customer> result = new List<Customer>();
            foreach (Customer item in customerCollection)
            {
                if (del(item))
                    result.Add(item);
            }
            return result;
        }



    }
}
