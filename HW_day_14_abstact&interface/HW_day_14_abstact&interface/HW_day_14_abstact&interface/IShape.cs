using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_14_abstact_interface
{
    internal interface IShape
    {
        public abstract double Perimeter();
        public abstract double Area();
        public double Distance(Point p1, Point p2)
        {
            int distance = (int)Math.Pow(p2.X - p1.X, 2) + (int)Math.Pow(p2.Y - p1.Y, 2);
            return Math.Sqrt(distance);
        }
    }
}
