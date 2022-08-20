using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project1.Models
    {
    public class Customer
        {
        public int Id { get; set; }
        public string Name { get; set; }
        }

    public class CustomerList
        {
        public List<Customer> Customers = new List<Customer>()
            {
            new Customer() { Id = 1, Name = "Rituraj"},
            new Customer() { Id = 2, Name = "Anurag"},
            new Customer() { Id = 3, Name = "Vivek"},
            new Customer() { Id = 4, Name = "Adnan"},
            new Customer() { Id = 5, Name = "Naman"},
            };
        }
    }