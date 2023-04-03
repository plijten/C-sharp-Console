using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periode_5_1
{
    public class Dice
    {
        public int Ogen { get; private set; }
        public bool blocked { get; set; }

        public void Gooi()
        {
            if (!blocked)
            {
                Random rnd = new Random();
                Ogen = rnd.Next(1, 7);
            }
            
        }

        public int GetOgen() {
            return Ogen;
        }
    }
}
