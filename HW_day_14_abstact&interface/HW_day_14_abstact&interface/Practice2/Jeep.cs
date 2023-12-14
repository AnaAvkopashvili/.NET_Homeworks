using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Jeep : Commercial
    {
        public Jeep(string name, int year, string cargoSpace) : base(name, year, cargoSpace)
        {
        }

        public static void DisplayJeep()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter cargo space: ");
            string cargoSpace = Console.ReadLine();
            Jeep jeep = new Jeep(name, year, cargoSpace);
            Console.WriteLine($"name: {name}, year: {year}, cargo space: {cargoSpace} ");

        }
    }
}
