using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Sports : Vehicle
    {
        public int Speed {  get; set; }
        public Sports(string name, int year, int speed) : base(name, year)
        {
            Speed = speed;
        }

        public override void Info()
        {
            Console.WriteLine("This vehicle is a Sports car");
        }
    }
    
}
