using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
     class PublicTransport : Vehicle
     {
        public int Capacity { get; set; }
        protected PublicTransport(string name, int year, int capacity) : base(name, year)
        {
            Capacity = capacity;
        }
        public override void Info()
        {
            Console.WriteLine("this vehicle is Public transport");
        }
     }

   
}
