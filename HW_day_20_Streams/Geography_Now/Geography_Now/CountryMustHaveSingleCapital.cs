using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography_Now
{
    internal class CountryMustHaveSingleCapital : Exception

    {
        public CountryMustHaveSingleCapital(string message) : base(message) 
        {

        }
    }
}
