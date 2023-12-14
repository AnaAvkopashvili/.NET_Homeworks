using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Bus : PublicTransport
    {
        public Bus(string name, int year, int capacity) : base(name, year, capacity)
        {
        }
        public static void DisplayBus()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter capacity: ");
            Bus bus = new Bus(name, year, capacity);
            Console.WriteLine($"name: {name}, year: {year}, capacity: {capacity} ");

        }
    }
}
