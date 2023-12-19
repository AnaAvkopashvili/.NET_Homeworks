
namespace PointCalculations
{
    internal class Program
    {
        public static int PointCalculation(Tuple<int, int> point1, Tuple<int, int> point2)
        {
            return (int) Math.Sqrt(Math.Pow(point2.Item2 - point1.Item2, 2) + Math.Pow(point2.Item1 - point1.Item1, 2));
        }
        static void Main(string[] args)
        {
            Console.WriteLine(PointCalculation(new Tuple<int, int>(1, 1), new Tuple<int, int>(4, 2)));
        }
    }
}