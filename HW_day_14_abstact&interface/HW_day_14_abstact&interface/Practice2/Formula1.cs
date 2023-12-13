using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Formula1 : Sports
    {
        public Formula1(string name, int year, int speed) : base(name, year, speed)
        {
        }
        public static void DisplayFormula1()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            int speed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter speed: ");
            Formula1 formula = new Formula1(name, year, speed);
            Console.WriteLine($"name: {name}, year: {year}, speed: {speed} ");
        }

    }
}
