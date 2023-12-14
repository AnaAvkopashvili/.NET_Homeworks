using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
      class Combat : Vehicle
     {
        public string ArmorStrength { get; set; }
        public Combat(string name, int year, string armor) : base(name, year)
        {
            ArmorStrength = armor;
        }
        public override void Info()
        {
            Console.WriteLine("This vehicle is Combat");
        }
  
        public void Fire() 
        {
            Console.WriteLine("Firing...");
        }
    }
   
}

