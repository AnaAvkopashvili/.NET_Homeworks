using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_25_Linq
{
    public class Customers
    {
        public string CustomerName {  get; set; }
        public int CustomerID { get; set; }
        public Customers(int  customerID, string cutomerName) 
        {
            CustomerID = customerID;
            CustomerName = cutomerName;
        }
    }
}
