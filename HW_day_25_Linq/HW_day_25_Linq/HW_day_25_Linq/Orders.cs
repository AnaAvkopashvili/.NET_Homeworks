using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_25_Linq
{
    public class Orders
    {
        public int OrderID { get; set; }
        public string Date { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public int CustomerID { get; set; }

        public Orders(int orderId, string date, string product, double price, int customerId)
        {
            OrderID = orderId;
            Date = date;
            Product = product;
            Price = price;
            CustomerID = customerId;
        }
    }
}
