namespace Practice_2
{
    internal class Triange
    {
        int _Side1;
        int _Side2;
        int _Side3;

        public int Side1
        {
            get { return _Side1; }
            set
            {
                _Side1 = value;
            }
        }
        public int Side2
        {
            get { return _Side2; }
            set
            {
                _Side2 = value;
            }
        }
        public int Side3
        {
            get { return _Side3; }
            set
            {
                _Side3 = value;

                if ((_Side1 + _Side2 <= _Side3) || (_Side2 + _Side3 <= _Side1) || (_Side1 + _Side3 <= _Side2))
                    Console.WriteLine("It is not a valid triangle.");
            }
        }

        public int Perimeter(int n1, int n2, int n3)
        {
            return n1 + n2 + n3;
        }
        public int Area(int n1, int n2, int n3)
        {
            int s = Perimeter(n1, n2, n3) / 2;

            return (int)Math.Pow((s * (s - n1) * (s - n2) * (s - n3)), 0.5);
        }

        static void Main(string[] args)
        {
            Triange triangle = new Triange();
            Console.Write("Enter side 1: ");
            triangle.Side1 = int.Parse(Console.ReadLine());
            Console.Write("Enter side 2: ");
            triangle.Side2 = int.Parse(Console.ReadLine());
            Console.Write("Enter side 3: ");
            triangle.Side3 = int.Parse(Console.ReadLine());

            if (triangle.Side1 + triangle.Side2 > triangle.Side3 
                && triangle.Side1 + triangle.Side3 > triangle.Side2
                && triangle.Side2 + triangle.Side3 > triangle.Side1)
            {
                Console.WriteLine("Perimiter of the triangle is " + triangle.Perimeter(triangle.Side1, triangle.Side2, triangle.Side3));
                Console.WriteLine("Area of the triangle is " + triangle.Area(triangle.Side1, triangle.Side2, triangle.Side3));
            }
        }
    }
}


