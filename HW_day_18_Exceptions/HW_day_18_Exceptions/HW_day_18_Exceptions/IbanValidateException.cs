using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_18_Exceptions
{
    class IbanValidateException : Exception
    {
        public IbanValidateException(string message) : base(string.Format("Invalid IBAN! {0}", message))
        { 
        }
    }
}
