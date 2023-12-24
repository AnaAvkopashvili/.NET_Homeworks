using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_18_Exceptions
{
    internal class AmountValidateException : Exception
    {
        public AmountValidateException(string message) : base(string.Format("Invalid amount! {0}", message))
        {
        }
    }
}
