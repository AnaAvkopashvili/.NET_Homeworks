namespace Practice2
{
    internal class Program
    {
        public enum Categories
        {
            Combat,
            Commercial,
            PublicTransport,
            Sports
        }
        public enum CombatEnum
        {
            Tank,
            Beteer
        }
        public enum CommercialEnum
        {
            Jeep,
            Bicycle
        }
        public enum PublicTransportEnum
        {
            Bus
        }
        public enum SportsEnum
        {
            Formula1
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose one of the following (write 0 - 4): ");
            foreach (Categories type in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine(type);
            }

            int x = int.Parse(Console.ReadLine());
            if (x == 0)
            {
                foreach (CombatEnum type in Enum.GetValues(typeof(CombatEnum)))
                {
                    Console.WriteLine(type);
                }
                Console.WriteLine("Please choose one of the following (write only integers): ");
                int choice = int.Parse(Console.ReadLine());
                
                if (choice == 0)
                {
                    Tank.DisplayTank();
                }
                else if (choice == 1)
                {
                    Beteer.DisplayBeteer();   
                }

            }
            else if(x == 1)
            {
                foreach (CommercialEnum type in Enum.GetValues(typeof(CommercialEnum)))
                {
                    Console.WriteLine(type);
                }
                Console.WriteLine("Please choose one of the following (write only integers): ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    Jeep.DisplayJeep();
                }
                else if (choice == 1)
                {
                    Bicycle.DisplayBicycle();
                }
            }
            else if (x == 2)
            {
                foreach (PublicTransportEnum type in Enum.GetValues(typeof(PublicTransportEnum)))
                {
                    Console.WriteLine(type);
                }
                Console.WriteLine("Please choose one of the following (write only integers): ");
                Bus.DisplayBus();
            }
            else if (x == 3)
            {
                foreach (SportsEnum type in Enum.GetValues(typeof(SportsEnum)))
                {
                    Console.WriteLine(type);
                }
                Console.WriteLine("Please choose one of the following (write only integers): ");
                Formula1.DisplayFormula1();
            }
                           
        }
    }
}