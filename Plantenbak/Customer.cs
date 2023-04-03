using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periode_5_1 {
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Insertion { get; set; }
        //public string Address { get; set; }
        public string City { get; set; }
        public string Postalcode { get; }
        public HomeAdress Address { get; set; }



        public Customer() { }   

        public Customer(string firstName, string lastName, string insertion, string address, string city, string postalcode) 
        { 
            FirstName = firstName;
            LastName = lastName;
            Insertion = insertion;
            //Address = address;
            City = city;
            Postalcode = postalcode;
        }

        public string PrintCustomer()
        {
            return $"{FirstName} {Insertion} {LastName}"
                + $"{Address} "
                + $"{City} "
                + $"{Postalcode}";
        }

    }
}
