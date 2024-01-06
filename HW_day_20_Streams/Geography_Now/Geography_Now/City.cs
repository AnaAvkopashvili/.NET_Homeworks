using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography_Now
{
    public class City : GeographicEntity
    {
        public string CityName { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public bool isCapital { get; set; }
        public City(string cityName, double area, int population, bool isCapital, string countryName)
        {
            CityName = cityName;
            Area = area;
            Population = population;
            this.isCapital = isCapital;
            CountryName = countryName;
        }
       
        
    }
}
