using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_14_abstact_interface
{
    internal class Square : Shape
    {
        public Point A {  get; set; }  
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }

        public Square(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public override double Area()
        {
            double side1 = Distance(A, B);
            double side2 = Distance(B, C);
            return side1 * side2;
        }

        public override double Perimeter()
        {
            double side1 = Distance(A, B);
            double side2 = Distance(B, C);
            return 2 * (side1 + side2);
        }
    }
}
