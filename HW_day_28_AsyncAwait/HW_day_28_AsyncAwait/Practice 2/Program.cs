using System.Diagnostics;

namespace Practice_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElectricCar car1 = new ElectricCar("model 1", 1990);
            ElectricCar car2 = new ElectricCar("model 2", 2000);
            ElectricCar car3 = new ElectricCar("model 3", 2010);
            List<ElectricCar> list = new List<ElectricCar>();
            list.Add(car1);
            list.Add(car2);
            list.Add(car3);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(DateTime.Now);
            car1.ChargeAll(list);
            stopwatch.Stop();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("RunTime " + stopwatch.Elapsed);
        }
    }
}