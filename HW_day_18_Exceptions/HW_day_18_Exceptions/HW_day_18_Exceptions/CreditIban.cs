using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_18_Exceptions
{
    class CreditIban : IBAN
    {
        public CreditIban(string ibanNumber) : base(ibanNumber)
        {

        }
        public override void withdraw(double amount)
        {
           available -= amount;
        }
    }
}
