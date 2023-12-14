using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
     class Commercial : Vehicle
    {
        public string CargoSpace { get; set; }

        public Commercial(string name, int year, string cargoSpace) : base(name, year)
        {
            CargoSpace = cargoSpace;    
        }
        public override void Info()
        {
            Console.WriteLine("This vehicle is Commercial");
        }

    }
  
}
