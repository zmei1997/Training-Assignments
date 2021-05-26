using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp7.Repository;
namespace ConsoleApp7
{
    class ManageCustomer
    {
        CustomerRepository customerRepository;
        public ManageCustomer()
        {
            customerRepository = new CustomerRepository();
        }

        public void Print()
        {
            List<Customer> customerCollection = customerRepository.WhereClause(c => c.Country=="USA" && c.City=="Tysons");
            foreach (var item in customerCollection)
            {
                Console.WriteLine($"{item.Id} \t {item.Name} \t {item.City} \t {item.Country}");
            }
        }
    }
}
