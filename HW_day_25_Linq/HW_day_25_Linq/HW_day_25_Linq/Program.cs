using System.Linq;

namespace HW_day_25_Linq
{
    internal class Program
    {
        public static List<Orders> ReadOrders(string orderPath)
        {
            List<Orders> orders = new List<Orders>();
            try
            {
                using (StreamReader sr = new StreamReader(orderPath))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        int orderID = int.Parse(parts[0]);
                        string date = parts[1];
                        string product = parts[2];
                        double price = double.Parse(parts[3]);
                        int customerID = int.Parse(parts[4]);
                        orders.Add(new Orders(orderID, date, product, price, customerID));
                    }
                }
                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading orders file: " + ex.ToString());
                return new List<Orders>() { };
            }
        }
        public static List<Customers> ReadCustomers(string customerPath)
        {
            List<Customers> customers = new List<Customers>();
            try
            {
                using (StreamReader sr = new StreamReader(customerPath))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        int customerID = int.Parse(parts[0]);
                        string customerName = parts[1];
                        customers.Add(new Customers(customerID, customerName));
                    }
                }
                return customers;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading customers file: " + ex.ToString());
                return new List<Customers>() { };   
            }
        }
        static void Main(string[] args)
        {
            string orderPath = "C:\\Users\\Kiu-Student\\Desktop\\orders.txt";
            string customerPath = "C:\\Users\\Kiu-Student\\Desktop\\customers.txt";
            List<Orders> orderList = ReadOrders(orderPath);
            List<Customers>  customersList = ReadCustomers(customerPath);

            //1

            var countOrders = from o in orderList
                              group o by o.CustomerID into customersGrouped
                              select new
                              {
                                  CustomerID = customersGrouped.Key,
                                  OrderCount = customersGrouped.Count()
                              };
            Console.WriteLine("CustomerID\tOrderCount");
            foreach (var result in countOrders)
            {
                Console.WriteLine($"{result.CustomerID}\t\t{result.OrderCount}");
            }

            // method syntax
            var countOrdersMethod = orderList.GroupBy(o => o.CustomerID);
            Console.WriteLine("CustomerID\tOrderCount");

            foreach (var group in countOrdersMethod)
            {
                Console.WriteLine(group.Key + "\t\t" + group.Count());
            }

            //2

            var priceSum = from o in orderList
                           group o by o.CustomerID into customerGrouped
                           select new
                           {
                               CustomerID = customerGrouped.Key,
                               SumAmount = customerGrouped.Sum(o => o.Price)
                           };
            Console.WriteLine("CustomerID\tPriceSum");
            foreach (var result in priceSum)
            {
                Console.WriteLine($"{result.CustomerID}\t\t{result.SumAmount}");
            }

            // method sytax

            var priceSumMethod = orderList.GroupBy(o => o.CustomerID);
            Console.WriteLine("CustomerID\tPriceSum");
            foreach (var result in priceSumMethod)
            {
                Console.WriteLine($"{result.Key}\t\t{result.Sum(o => o.Price)}");
            }

            //3

            var minPriceOrders = from o in orderList
                                 group o by o.CustomerID into customerGrouped
                                 select new
                                 {
                                     customerID = customerGrouped.Key,
                                     minPrice = customerGrouped.Min(o => o.Price)
                                 };
            Console.WriteLine("CustomerID\tMinPrice");
            foreach (var result in minPriceOrders)
            {
                Console.WriteLine($"{result.customerID}\t\t{result.minPrice}");
            }

            // method syntax

            var minPriceOrdersMethod = orderList.GroupBy(o => o.CustomerID);
            Console.WriteLine("CustomerID\tMinPrice");
            foreach (var result in minPriceOrdersMethod)
            {
                Console.WriteLine($"{result.Key}\t\t{result.Min(o => o.Price)}");
            }

            //4 

            var countOrdersWithCondition = from o in orderList
                                           group o by o.CustomerID into customersGrouped
                                           where customersGrouped.Count() > 1
                                           select new
                                           {
                                               CustomerID = customersGrouped.Key,
                                               OrderCount = customersGrouped.Count()
                                           };
            Console.WriteLine("CustomerID\tOrderCount");
            foreach (var result in countOrdersWithCondition)
            {
                Console.WriteLine($"{result.CustomerID}\t\t{result.OrderCount}");
            }

            // method syntax

            var countOrdersWithConditionMethod = orderList.GroupBy(o => o.CustomerID).Where(o => o.Count() > 1);
            Console.WriteLine("CustomerID\tOrderCount");
            foreach (var result in countOrdersWithConditionMethod)
            {
                Console.WriteLine($"{result.Key}\t\t{result.Count()}");
            }


            //5

            var averageOrders = from o in orderList
                                group o by o.CustomerID into customerGroup
                                where customerGroup.Average(o => o.Price) > 10.0
                                select new
                                {
                                    CustomerID = customerGroup.Key,
                                    AvgAmount = customerGroup.Average(o => o.Price)
                                };
            Console.WriteLine("CustomerID\tOrderCount");
            foreach (var result in averageOrders)
            {
                Console.WriteLine($"{result.CustomerID}\t\t{result.AvgAmount}");
            }

            // method syntax

            var averageOrdersMethod = orderList.GroupBy(o => o.CustomerID).Where(o => o.Average(o => o.Price) > 10.0);
            Console.WriteLine("CustomerID\tOrderCount");
            foreach (var result in averageOrdersMethod)
            {
                Console.WriteLine($"{result.Key}\t\t{result.Average(o => o.Price)}");
            }

        }
    }
}