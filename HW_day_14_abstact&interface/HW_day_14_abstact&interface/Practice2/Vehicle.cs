using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
     abstract class Vehicle
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Vehicle(string name, int year)
        {
            Name = name;
            Year = year;
        }
        public abstract void Info();
    }
}
