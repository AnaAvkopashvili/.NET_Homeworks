using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_22_Delegates
{
    public class MathOperation
    {
        public static Decimal Add(Decimal a, Decimal b)
        {
            return a + b;
        }
        public static Decimal Sub(Decimal a, Decimal b)
        {
            return a - b;
        }
        public static Decimal Div(Decimal a, Decimal b)
        {
            return a / b;
        }
        public static Decimal Mul(Decimal a, Decimal b)
        {
            return a * b;
        }
    }
}
