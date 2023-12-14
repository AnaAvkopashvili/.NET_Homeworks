using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_14_abstact_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter x coordinate for point a: ");
            int ax = int.Parse(Console.ReadLine());

            Console.Write("Enter y coordinate for point a: ");
            int ay = int.Parse(Console.ReadLine());

            Console.Write("Enter x coordinate for point b: ");
            int bx = int.Parse(Console.ReadLine());

            Console.Write("Enter y coordinate for point b: ");
            int by = int.Parse(Console.ReadLine());

            Console.Write("Enter x coordinate for point c: ");
            int cx = int.Parse(Console.ReadLine());

            Console.Write("Enter y coordinate for point c: ");
            int cy = int.Parse(Console.ReadLine());

            Console.Write("Enter x coordinate for point d: ");
            int dx = int.Parse(Console.ReadLine());

            Console.Write("Enter y coordinate for point d: ");
            int dy = int.Parse(Console.ReadLine());

            Point a = new Point(ax, ay);
            Point b = new Point(bx, by);
            Point c = new Point(cx, cy);
            Point d = new Point(dx, dy);

            Shape[] shapes = { new Triangle(a, b, c), new Circle(a, b), new Square(a, b, c, d) };
            foreach (Shape shape in shapes)
            {
                Triangle t = shape as Triangle;
                Circle circ = shape as Circle;
                Square s = shape as Square;

                if (t != null)
                {
                    Console.WriteLine("area of a triangle: " + t.Area());
                    Console.WriteLine("perimeter of a triangle: " + t.Perimeter());
                }
                if (s != null)
                {
                    Console.WriteLine("area of a rectangle: " + s.Area());
                    Console.WriteLine("perimeter of a rectangle: " + s.Perimeter());
                }
                if (circ != null)
                {
                    Console.WriteLine("Area of a circle: " + circ.Area());
                    Console.WriteLine("Perimeter of a circle: " + circ.Perimeter());
                }
            }

        }
    }
}
