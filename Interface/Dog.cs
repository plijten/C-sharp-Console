using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Dog : IAnimal
    {
        public string Move()
        {
            return "Dog is moving";
        }
        public string MakeSound()
        {
            return "Dog is making sound";
        }

        public void eat()
        {
            throw new NotImplementedException("Hond kan nog niet eten.");
        }
    }
}
