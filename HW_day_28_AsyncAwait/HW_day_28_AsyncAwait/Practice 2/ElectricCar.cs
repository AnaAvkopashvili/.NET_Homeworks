using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    public class ElectricCar
    {
        public int BatteryLevel {  get; set; }
        public string Model {  get; set; }
        public int Year { get; set; }

        public ElectricCar(string model, int year)
        {
            BatteryLevel = 0;
            Model = model;
            Year = year;
        }
        public void Charge()
        {
            while (BatteryLevel < 100)
            {
                Thread.Sleep(10000);
                BatteryLevel += 5;
            }
            Console.WriteLine($"Car {Model} charged - {BatteryLevel}");
        }

        public void ChargeAll(IEnumerable<ElectricCar> cars)
        {
            List<Thread> threads = new List<Thread>();
            foreach (var car in cars)
            {
                Thread chargeThread = new Thread(car.Charge);
                chargeThread.Start();
                threads.Add(chargeThread);
            }
            foreach (var t in threads)
            {
                t.Join();
            }
        }
    }
}
