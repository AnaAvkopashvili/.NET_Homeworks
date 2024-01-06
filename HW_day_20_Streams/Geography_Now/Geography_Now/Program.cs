using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Geography_Now
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Users\Kiu-Student\Desktop\Cities.txt";
            var cityDict = new Dictionary<string, City>();
            var countryDict = new Dictionary<string, Country>();

            List<string> cities = new List<string>();
            List<City> citiesList = new List<City>();
            List<Country> countriesList = new List<Country>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] str = line.Split('|');
                    cities.Add(str[0]);
                    try
                    {
                        string name = str[0].Trim();
                        double area = double.Parse(str[1].Replace(',', '.'));
                        int population = int.Parse(str[2].Trim());
                        bool isCapital = bool.Parse(str[3].Trim());
                        string country = str[4].Trim();

                        City city = new City(name, area, population, isCapital, country);
                        citiesList.Add(city);
                        cityDict.Add(name.ToLower(), city);

                        Country existingCountry = null;

                        foreach (Country c in countriesList)
                        {
                            if (c.CountryName == country)
                            {
                                existingCountry = c;
                                break;
                            }
                        }
                        var d = new Dictionary<string, string>();
                        if (existingCountry == null)
                        {
                            if (city.isCapital)
                            {
                                d.Add(name, "isCapital");

                            }
                            else
                            {
                                d.Add(name, "Not a capital");
                            }
                            Country newCountry = new Country(country, d, area, population);

                            countriesList.Add(newCountry);
                            countryDict.Add(country.ToLower(), newCountry);
                        }
                        else
                        {
                            if (city.isCapital)
                                existingCountry.Cities.Add(name, "isCapital" );

                            else
                                existingCountry.Cities.Add(name, "Not a capital");

                            existingCountry.Area += area;
                            existingCountry.Population += population;
                            countryDict[country.ToLower()] = existingCountry;
                        }
                        int count = 0;

                        foreach (var v in d.Values)
                        {
                            if (v == "isCapital")
                                count++;
                        }
                        if (count > 1)
                        {
                            GeographicEntity.LogErrorMessage("country must have single capital");
                            throw new CountryMustHaveSingleCapital(" country must have single capital");
                        }

                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        GeographicEntity.LogErrorMessage("index out of range");
                        Console.WriteLine("index out of range");
                    }
                }
            }
            Console.WriteLine("Choose, only enter 1 or 2: \n 1. Search Country 2. Search City.");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                Console.Write("Choose a country: ");
                string country = Console.ReadLine().ToLower();
                if (countryDict.ContainsKey(country))
                {
                    Console.WriteLine($"info about {country}:");
                    Country c = countryDict[country];

                    Console.WriteLine($"Country: {c.CountryName}, Total Area: {c.Area}, Total Population: {c.Population}, " +
                           $"Cities: {string.Join(", ", c.Cities)}");
                }
                else
                {
                    Console.WriteLine("Country not found.");
                }
            }
            if (input == 2)
            {
                Console.WriteLine("Choose a city: ");
                string city = Console.ReadLine().ToLower();
                if (cityDict.ContainsKey(city))
                {
                    Console.WriteLine($"info about {city}:");
                    City c = cityDict[city];
                    if (c.isCapital)
                    {
                        Console.WriteLine($"city: {c.CityName}, Area: {c.Area}, Population: {c.Population}, Capital: {c.isCapital}," +
                           $" Country: {c.CountryName}");
                    }
                    Console.WriteLine($"city: {c.CityName}, Area: {c.Area}, Population: {c.Population}, Country: {c.CountryName}");
           
                }
                else
                {
                    Console.WriteLine("City not found.");
                }
            }
            

        }

       
    }
}