namespace Practice_1
{
    internal class Cat
    {
        string _Name;
        string _Breed;
        int _Age;
        string _Sex;
        private int Grams => 10;

        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                if (value > 2) // 18 in cat years
                    _Age = value;
            }
        }

        public string Breed
        {
            get { return _Breed; }
            set { _Breed = value; }
        }

        public string Name { get; set; }

        public string Sex { get; set; }
        public void Meow(int n)
        {
            for (int i = 0; i < n; i++) 
                Console.WriteLine("Meowing..");
        }
        public void Eat(int n)
        {
            while( n >= 0)
            {
                Console.WriteLine("Eating...");
                n -= Grams;
            }
        }

        static void Main(string[] args)
        {
            Cat cat = new Cat();

            Console.WriteLine("Creating cat object...");
            Console.Write("Enter name: ");
            cat.Name = Console.ReadLine();
            Console.Write("Enter breed: ");
            cat.Breed = Console.ReadLine();
            Console.Write("Enter sex: ");
            cat.Sex = Console.ReadLine();
            Console.WriteLine("Cat object created.");
            Console.Write("Enter food weight in grams: ");
            int grams = int.Parse(Console.ReadLine());
            Console.WriteLine(cat.Name + " started eating ");
            cat.Eat(grams);
            Console.WriteLine(cat.Name + " finished eating ");
            Console.Write("enter meowing count: ");
            int count = int.Parse(Console.ReadLine());
            cat.Meow(count);
        }
    }
}
