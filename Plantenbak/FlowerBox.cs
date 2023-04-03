using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantenbak
{

    public enum Enum_Form
    {
        Kubus,
        Balk,
        Cilinder
    }
    public class FlowerBox
    {
        private int length;
        private int width;
        private int height;

        private Enum_Form form;

        public FlowerBox(int _length, int _width, int _height)
        {
            length = _length;
            width = _width;
            height = _height;
        }

        public int Volume()
        {
            return length * width * height;
        }

        public double Surface()
        {
            return length * height;
        }

        public string PrintFlowerBox()
        {
            string text = "Afmetingen: \n";
            text += $"Lengte: {length} \n";
            text += $"Breedte: {width} \n";
            text += $"Hoogte: {height} \n";
            text += $"Volume: {Volume()} \n";

            return text;
        }

        public decimal Price(bool pottingSoil)
        {
            if (pottingSoil)
            {
                return Convert.ToDecimal((Volume() * 0.0002) + (Volume() * 0.002));
            }
            else
            {
                return Convert.ToDecimal(Volume() * 0.002);
            }
        }
    }
}