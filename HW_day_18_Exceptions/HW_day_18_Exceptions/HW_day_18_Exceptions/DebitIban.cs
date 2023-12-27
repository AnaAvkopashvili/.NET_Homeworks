using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_18_Exceptions
{
    class DebitIban : IBAN
    {
        public DebitIban(string ibanNumber) : base(ibanNumber)
        {
        }
        public override void withdraw(double amount)
        {
            if(available >= amount)
            {
                available -= amount;
            }
            else
            {
                throw new AmountValidateException("rejected, not enough money available.");
            }
        }
    }
}
