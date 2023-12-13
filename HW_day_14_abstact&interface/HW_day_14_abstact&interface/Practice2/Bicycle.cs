using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Bicycle : Commercial
    {
        public int Pedals { get; set; }
        public Bicycle(string name, int year, string cargoSpace, int pedals) : base(name, year, cargoSpace)
        {
            Pedals = 2;
        }

        public static void DisplayBicycle()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter cargo space: ");
            string cargoSpace = Console.ReadLine();
            int pedals = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter pedals: ");
            Bicycle bicycle = new Bicycle(name, year, cargoSpace, pedals);
            Console.WriteLine($"name: {name}, year: {year}, cargo space: {cargoSpace}, pedals: {pedals} ");

        }
    }
}
