using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_18_Exceptions
{
    internal class User
    {
        public string userName;
        public IBAN account;
        public int PIN;

        public User(string userName, IBAN account, int PIN)
        {
            this.userName = userName;
            this.account = account;
            this.PIN = PIN;
        }
    }
}
