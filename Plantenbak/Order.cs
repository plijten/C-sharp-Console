using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periode_5_1
{
    public class Order
    {
        public Customer ObjectCustomer { get; set; }

        public Order(Customer objectCustomer)
        {
            ObjectCustomer = objectCustomer;
        }

        public Order(string firstname, string lastname, HomeAdress adress)
        {
            Customer customer = new Customer(); 
            customer.FirstName = firstname;
            customer.LastName = lastname;   
            ObjectCustomer= customer;
        }

        public Order(string firstname, string lastname, string street, string city)
        {
            Customer customer = new Customer();
            HomeAdress addres = new HomeAdress();
            addres.City = city;
            addres.Street = street;

            customer.FirstName = firstname;
            customer.LastName = lastname;
            customer.Address = addres;
            ObjectCustomer = customer;
        }
    }
}
