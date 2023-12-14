using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_14_abstact_interface
{
    //აბსტარქტ კლასის შემთხვევა
    internal class Circle : Shape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Circle(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public override double Area()
        {

            return Math.PI * Distance(A,B) * Distance(A,B);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Distance(A,B);
        }
    }



    // ინტერფეისის შემთხვევა
    internal class CircleInter : IShape
    {
        public Point A {  get; set; }  
        public Point B { get; set; }
        public CircleInter(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public double Area()
        {
            
            return Math.PI * Radius() * Radius();
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius();
        }
        public double Radius()
        {
            Circle circle1 = new Circle(A, B);
            IShape circle2 = (IShape)circle1;
            double radius = circle2.Distance(A, B);
            return radius;
        }
    }
}
