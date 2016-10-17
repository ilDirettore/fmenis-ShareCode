using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es1_ifruit
{
    class Apple : IFruit
    {
        private string _name = "Apple";
        private double _price = 1.5;
        public string getName()
        {
            return _name;
        }

        public double getPrice()
        {
            return _price;
        }
    }
}
