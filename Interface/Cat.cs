using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Cat : IAnimal
    {
        public string Move()
        {
            return "Cat is moving";
        }
        public string MakeSound()
        {
           return "Cat is making sound";
        }

        public void Scratch()
        {
            throw new NotImplementedException("Cat can't scratch yet.");
        }
    }
}
