using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp4.Model;

namespace ConsoleApp4.Repository
{
    class CustomerRepository : IRepository<Customer>
    {
        List<Customer> customerCollection = new List<Customer>();
        public void Add(Customer item)
        {
            customerCollection.Add(item);
        }

        public void Delete(int id)
        {
            Customer c = GetById(id);
            if (c != null)
                customerCollection.Remove(c);
        }

        public List<Customer> GetAll()
        {
            return customerCollection;
        }

        public Customer GetById(int id)
        {
            foreach(Customer item in customerCollection)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public void Update(Customer item)
        {
            Customer c = GetById(item.Id);
            if (c != null) 
            { 
            
                c.FullName = item.FullName;
                c.City = item.City;
            }
        }
    }
}
