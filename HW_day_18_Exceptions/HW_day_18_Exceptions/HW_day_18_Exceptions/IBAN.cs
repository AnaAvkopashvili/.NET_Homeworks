using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace HW_day_18_Exceptions
{
    class IBAN
    {
        internal string ibanNumber;
        internal double available;

        public IBAN(string ibanNumber)
        {
            if (ibanNumber.Length > 22)
            {
                throw new IbanValidateException("characters exceeded.");
            }
            else if (ibanNumber.Length < 22)
            {
                throw new IbanValidateException("characters missing.");
            }
            else
            {
                this.ibanNumber = ibanNumber;
            }
            this.available = 0.0;
        }
        public void deposit(double amount)
        {
            available += amount;
        }
        public virtual void withdraw(double amount)
        {

        }
    }
}
