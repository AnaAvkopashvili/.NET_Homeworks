using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_14_abstact_interface
{
    internal class Triangle : Shape
    {
        Point A { get; set; }
        Point B { get; set; }
        Point C { get; set; }
        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }
    
        public override double Area()
        {
            Triangle t = new Triangle(A, B, C);
            double s = t.Perimeter() / 2;
            double result = s * (s - Distance(A,B)) * (s - Distance(B,C)) * (s - Distance(C, A));
            return Math.Sqrt(result);
        }

        public override double Perimeter()
        {
            double side1 = Distance(A,B);
            double side2 = Distance(B,C);
            double side3 = Distance(C,A);
            return side1 + side2 + side3;
        }
    }
}
