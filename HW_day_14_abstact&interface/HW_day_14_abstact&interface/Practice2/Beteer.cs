using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Beteer : Combat
    {
        public string SpecialWeapon { get; set; }

        public Beteer(string name, int year, string armor, string specialweapon) : base(name, year, armor)
        {
            SpecialWeapon = specialweapon;
        }
        public void ChangeSpecialWeapon(string newWeapon)
        {
            SpecialWeapon = newWeapon;
            Console.WriteLine($"Special weapon changed to: {SpecialWeapon}");
        }
        public static void DisplayBeteer()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter armor: ");
            string armor = Console.ReadLine();
            Console.WriteLine("Enter special weapon: ");
            string specialweapon = Console.ReadLine();
            Beteer beteer = new Beteer(name, year, armor, specialweapon);
            Console.WriteLine($"name: {name}, year: {year}, armor: {armor}, special weapon: {specialweapon} ");

        }
    }
}
