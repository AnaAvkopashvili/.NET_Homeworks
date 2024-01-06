using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Geography_Now
{
    public class Country : GeographicEntity
    {
        public Dictionary<string, string> Cities { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }

        public Country(string countryname, Dictionary<string, string> cities, double area, int population)
        {
            CountryName = countryname;
            Cities = cities;
            Area = area;
            Population = population;
        }
   
    }
}
