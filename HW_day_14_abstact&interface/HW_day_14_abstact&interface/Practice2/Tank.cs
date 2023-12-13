using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Tank : Combat
    {
        public string MainGun { get; set; }
        public Tank(string name, int year, string armor, string maingun) : base(name, year, armor)
        {
            MainGun = maingun;
        }
        public static void DisplayTank()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter armor: ");
            string armor = Console.ReadLine();
            Console.WriteLine("Enter main gun: ");
            string maingun = Console.ReadLine();
            Tank tank = new Tank(name, year, armor, maingun);
            Console.WriteLine($"name: {name}, year: {year}, armor: {armor}, maingun: {maingun} ");

        }
    }
}
