using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es1_ifruit
{
    class Ananas : IFruit
    {
        private string _name = "Ananas";
        private double _price = 1; 
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
